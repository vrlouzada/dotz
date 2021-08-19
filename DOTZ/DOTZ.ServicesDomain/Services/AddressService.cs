using DOTZ.Domain.Contracts.Helper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.ServicesDomain.Services
{
    public class AddressService : IAddressService
    {

        private readonly IAddressRepository _addressRepository;
        private readonly IUserSession _userSession;

        public AddressService(IAddressRepository addressRepository, IUserSession userSession)
        {
            _addressRepository = addressRepository;
            _userSession = userSession;
        }


        public Address Insert(Address address)
        {
            address.CostumerId = _userSession.UserId;

            var resultInsert = _addressRepository.Insert(address);

            if (resultInsert)
            {
                var addressResponse = _addressRepository.Get(_userSession.UserId, address.Description);
                return addressResponse;
            }
            else
            {
                throw new Exception("There was an error inserting the address.");
            }            
        }

        public List<Address> GetAll() => _addressRepository.GetList(_userSession.UserId);

        public Address Get(int addressId) => _addressRepository.Get(addressId);

    }
}
