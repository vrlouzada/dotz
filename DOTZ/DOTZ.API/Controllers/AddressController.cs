using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.Entity;
using DOTZ.Domain.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DOTZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var response = _addressService.GetAll();
            return Ok(response);
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
