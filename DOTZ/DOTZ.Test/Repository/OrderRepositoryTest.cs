using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DOTZ.Test.Repository
{
    public class OrderRepositoryTest
    {

        private readonly IOrderRepository _orderRepository;


        public OrderRepositoryTest()
        {
            var ioc = Startup.IoC();
            _orderRepository = ioc.GetInstance<IOrderRepository>();
        }

        [Theory]
        [InlineData(2)]
        public void GetList(int costumerId)
        {
            var result = _orderRepository.GetList(costumerId);

            Assert.NotEmpty(result);
        }


        [Theory]
        [InlineData(2, 5, 6, 2, 0, "2021-08-19")]
        public void Insert(int costumerId, int productId, int addressId, int orderStatusId, double amount, string dateString)
        {

            var date = DateTime.Parse(dateString);

            var order = new Orders
            {
                CostumerId = costumerId,
                ProductId = productId,
                AddressId = addressId,
                OrderStatusId = orderStatusId,
                Date = date,
                Amount = amount
            };

            var result = _orderRepository.Insert(order);

            Assert.True(result);
        }

    }
}
