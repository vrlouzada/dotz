using DOTZ.Domain.Contracts.Helper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.DTO;
using DOTZ.Domain.Entity;
using DOTZ.Domain.Helper;
using DOTZ.Domain.Values;
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
        private readonly ICostumerRepository _costumerRepository;
        private readonly IBalanceService _balanceService;

        public OrderService(IUserSession userSession, IProductRepository productRepository, IOrderRepository orderRepository, ICostumerRepository costumerRepository, IBalanceService balanceService)
        {
            _userSession = userSession;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _costumerRepository = costumerRepository;
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
                    var response = new OrderStatusResponse
                    {
                        OrderDate = order.Date,
                        OrderStatus = EnumHelper.GetDescription(OrderStatusValues.ORDER_REQUESTED),
                        ProductName = product.Name
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
    }
}
