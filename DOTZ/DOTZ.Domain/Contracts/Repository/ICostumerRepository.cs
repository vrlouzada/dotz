using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.Contracts.Repository
{
    public interface ICostumerRepository
    {
        Costumer Get(int userId);
        bool Insert(Costumer costumer);
        bool Update(Costumer costumer);
        double GetBalance(int userId);
        bool UpdateBalance(int userId, double balance);
    }

}
