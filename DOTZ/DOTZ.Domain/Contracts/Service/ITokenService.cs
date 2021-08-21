using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.Contracts.Service
{

    public interface ITokenService
    {
        string GenerateToken(Costumer costumer);
    }

}
