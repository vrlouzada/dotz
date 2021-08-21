using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.Contracts.Service
{
    public interface IBalanceService
    {
        bool UpdateBalance(double balance);
    }

}
