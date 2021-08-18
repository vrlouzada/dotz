using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace DOTZ.Domain.Contracts.Helper
{
    public interface IUserSession
    {
        Costumer GetCostumer();
    }

}
