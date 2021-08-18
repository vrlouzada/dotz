using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.Contracts.Repository
{
    public interface IUserRepository
    {
        User Get(string login, string pass);
        bool Create(User user);
        User Get(int userId);
    }

}
