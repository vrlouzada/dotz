using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DOTZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtractController : ControllerBase
    {
        private readonly IExtractService _extractService;

        public ExtractController(IExtractService extractService)
        {
            _extractService = extractService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            try
            {
                var response = _extractService.GetExtract();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
