using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.DTO;
using DOTZ.Domain.Helper;
using DOTZ.Domain.Values;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DOTZ.Test.Service
{
    public class OrderServiceTest
    {
        private readonly IOrderService _orderService;

        public OrderServiceTest()
        {
            var ioc = Startup.IoC();
            _orderService = ioc.GetInstance<IOrderService>();
        }


        [Theory]
        [InlineData(2, 5)]
        public void Insert(int productId, int adrressId)
        {
            var request = new OrderRequest
            {
                ProductId = productId,
                AddressId = adrressId
            };

            var response = _orderService.SetOrder(request);

            Assert.NotNull(response);
            Assert.Equal(EnumHelper.GetDescription(OrderStatusValues.ORDER_REQUESTED), response.OrderStatus);
        }

        [Fact]
        public void GetOrders()
        {
            var orders = _orderService.GetOrders();

            Assert.NotEmpty(orders);
        }
    }
}
