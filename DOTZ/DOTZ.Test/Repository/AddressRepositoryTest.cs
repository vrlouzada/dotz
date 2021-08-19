using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DOTZ.Test.Repository
{
    public class AddressRepositoryTest
    {

        private readonly IAddressRepository _addressRepository;

        public AddressRepositoryTest()
        {
            var ioc = Startup.IoC();
            _addressRepository = ioc.GetInstance<IAddressRepository>();
        }

        
        [Theory]
        [InlineData("Minha Casa", 1, "Rua ABC", 123, "Bloco 1", "12345-25", "Irajá", "Rio de Janeiro", "RJ")]
        [InlineData("Trabalho", 1, "Rua do Trabalho", 999, "10 Andar", "54321-25", "Centro", "Rio de Janeiro", "RJ")]
        public void Insert(string description, int costumerId, string street, int number, string complement, string postalCode, string neighborhood, string city, string state)
        {
            var address = new Address
            {
                Description = description,
                CostumerId = costumerId,
                Street = street,
                Number = number,
                Complement = complement,
                PostalCode = postalCode,
                Neighborhood = neighborhood,
                City = city,
                State = state
            };

            var result = _addressRepository.Insert(address);

            Assert.True(result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(2)]
        public void Get(int id)
        {
            var address = _addressRepository.Get(id);

            Assert.NotNull(address);
            Assert.Equal(id, address.Id);
        }

        [Theory]
        [InlineData(1, "trabalho")]
        public void GetBydescription(int costumerId, string description)
        {
            var address = _addressRepository.Get(costumerId, description);

            Assert.NotNull(address);
            Assert.Equal(costumerId, address.CostumerId);
            Assert.Equal(description.ToUpper(), address.Description.ToUpper());
        }


        [Theory]
        [InlineData(1)]
        public void GetList(int costumerId)
        {
            var result = _addressRepository.GetList(costumerId);

            Assert.NotEmpty(result);
            Assert.Contains(result, a => a.CostumerId == costumerId);
            Assert.DoesNotContain(result, a => a.CostumerId != costumerId);
        }

        [Theory]
        [InlineData(4, "Minha Antiga Casa", 1, "Rua ABC", 123, "Bloco 1", "12345-25", "Irajá", "Rio de Janeiro", "RJ")]
        public void Update(int id, string description, int costumerId, string street, int number, string complement, string postalCode, string neighborhood, string city, string state)
        {
            var address = new Address
            {
                Id = id,
                Description = description,
                CostumerId = costumerId,
                Street = street,
                Number = number,
                Complement = complement,
                PostalCode = postalCode,
                Neighborhood = neighborhood,
                City = city,
                State = state
            };

            var result = _addressRepository.Update(address);

            Assert.True(result);
        }
    }
}
