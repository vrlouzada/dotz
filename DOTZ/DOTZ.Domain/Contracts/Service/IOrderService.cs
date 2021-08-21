using DOTZ.Domain.DTO;
using System.Collections.Generic;

namespace DOTZ.Domain.Contracts.Service
{
    public interface IOrderService
    {
        OrderStatusResponse SetOrder(OrderRequest orderRequest);

        List<OrderStatusResponse> GetOrders();
    }

}
