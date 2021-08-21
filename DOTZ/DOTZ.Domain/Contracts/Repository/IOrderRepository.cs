using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.Contracts.Repository
{
    public interface IOrderRepository
    {
        List<Orders> GetList(int costumerId);
        bool Insert(Orders order);
    }
}
