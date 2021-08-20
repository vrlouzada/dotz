using DOTZ.Domain.DTO;

namespace DOTZ.Domain.Contracts.Service
{
    public interface IOrderService
    {
        OrderStatusResponse SetOrder(OrderRequest orderRequest);
    }

}
