using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DOTZ.Test.Service
{
    public class AddressServiceTest
    {

        private readonly IAddressService _addressService;


        public AddressServiceTest()
        {
            var ioc = Startup.IoC();
            _addressService = ioc.GetInstance<IAddressService>();
        }

        [Theory]
        [InlineData("Minha casa 2", "Rua A", 10, "2345", "Iraja", "Rio de Janeiro", "RJ")]
        public void Insert(string description, string street, int number, string postalCode, string neighborhood, string city, string state)
        {
            var address = new Address
            {
                Description = description,
                Street = street,
                Number = number,
                PostalCode = postalCode,
                Neighborhood = neighborhood,
                City = city,
                State = state
            };

            var result = _addressService.Insert(address);

            Assert.True(result.Id != 0);
        }


        [Fact]
        public void GetAll()
        {
            var result = _addressService.GetAll();

            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData(4)]
        public void Get(int addressId)
        {
            var result = _addressService.Get(addressId);

            Assert.NotNull(result);
            Assert.Equal(addressId, result.Id);
        }

    }
}
