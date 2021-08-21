using DOTZ.Domain.Contracts.Helper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.DTO;
using DOTZ.Domain.Entity;
using DOTZ.Domain.Helper;
using DOTZ.Domain.Values;
using PELEXMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.ServicesDomain.Services
{
    public class OrderService : IOrderService
    {

        private readonly IUserSession _userSession;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IBalanceService _balanceService;

        public OrderService(IUserSession userSession, IProductRepository productRepository, IOrderRepository orderRepository, IAddressRepository addressRepository, IBalanceService balanceService)
        {
            _userSession = userSession;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _addressRepository = addressRepository;
            _balanceService = balanceService;
        }


        public OrderStatusResponse SetOrder(OrderRequest orderRequest)
        {

            var product = _productRepository.Get(orderRequest.ProductId);

            var order = new Orders
            {
                CostumerId = _userSession.UserId,
                Date = DateTime.Now,
                ProductId = orderRequest.ProductId,
                AddressId = orderRequest.AddressId,
                Amount = product.Amount,
                OrderStatusId = (int)OrderStatusValues.ORDER_REQUESTED
            };

            var result = _orderRepository.Insert(order);

            if (result)
            {

                var resultBalance = _balanceService.UpdateBalance(-order.Amount);

                if (resultBalance)
                {
                    var address = _addressRepository.Get(orderRequest.AddressId);

                    var response = new OrderStatusResponse
                    {
                        OrderDate = order.Date,
                        OrderStatus = EnumHelper.GetDescription(OrderStatusValues.ORDER_REQUESTED),
                        ProductName = product.Name,
                        Address = MapperUtil.MapIgnoreDependences<AddressDTO>(address)
                    };

                    return response;
                }
                else
                {
                    throw new Exception("There was an error updating the costumer balance.");
                }
            }
            else
            {
                throw new Exception("There was an error inserting the order.");
            }

        }

        public List<OrderStatusResponse> GetOrders()
        {

            var response = new List<OrderStatusResponse>();

            var orders = _orderRepository.GetList(_userSession.UserId);

            foreach (var item in orders)
            {
                var address = _addressRepository.Get(item.AddressId);

                var product = _productRepository.Get(item.ProductId);

                var order = new OrderStatusResponse();
                order.Address = MapperUtil.MapIgnoreDependences<AddressDTO>(address);
                order.OrderStatus = EnumHelper.GetDescription((OrderStatusValues)item.OrderStatusId);
                order.OrderDate = item.Date;
                order.ProductName = product.Name;

                response.Add(order);
            }

            return response;

        }
    }
}
