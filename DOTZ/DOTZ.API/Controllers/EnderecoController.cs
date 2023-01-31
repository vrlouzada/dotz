using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.Entity;
using DOTZ.Domain.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DOTZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {

        private readonly IAddressService _addressService;

        public EnderecoController(IAddressService addressService)
        {
            _addressService = addressService;
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            return Ok("A redirec funcionou!!!");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Insert(Address address)
        {
            var response = _addressService.Insert(address);
            return Ok(response);
        }
    }
}
