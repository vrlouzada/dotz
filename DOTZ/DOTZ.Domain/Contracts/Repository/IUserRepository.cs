using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.Contracts.Repository
{
    public interface IUserRepository
    {
        UserAccounts Get(string login, string pass);
        bool Create(UserAccounts user);
        UserAccounts Get(int userId);
    }

}
