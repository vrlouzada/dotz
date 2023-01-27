using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.DTO;
using DOTZ.Domain.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DOTZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult SetOrder(OrderRequest orderRequest)
        {
            try
            {
                var response = _orderService.SetOrder(orderRequest);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            try
            {
                var response = _orderService.GetOrders();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
