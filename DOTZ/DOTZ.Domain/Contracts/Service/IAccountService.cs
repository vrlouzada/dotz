using DOTZ.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.Contracts.Service
{
    public interface IAccountService
    {
        AuthResponse Authenticate(AuthRequest request);
        AuthResponse CreateUser(LogonRequest logonRequest);
    }

}
