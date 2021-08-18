using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.Contracts.Repository
{
    public interface IProductRepository
    {
        Product Get(int id);
        List<Product> GetAll();
        bool UpdateStock(int id, int stock);
    }

}
