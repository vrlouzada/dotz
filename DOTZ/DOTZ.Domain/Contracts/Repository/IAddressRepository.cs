using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.Contracts.Repository
{

    public interface IAddressRepository
    {
        Address Get(int id);
        List<Address> GetList(int costumerId);
        bool Insert(Address address);
        bool Update(Address address);
    }

}
