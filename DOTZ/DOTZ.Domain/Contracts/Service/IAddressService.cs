using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.Contracts.Service
{
    public interface IAddressService
    {
        Address Get(int addressId);
        List<Address> GetAll();
        Address Insert(Address address);
    }
}
