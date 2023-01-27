using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DOTZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAvailableProducts()
        {
            try
            {
                var response = _productService.GetAvailabeProducts();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
