using Dapper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using DOTZ.Domain.Resources;
using System;

namespace DOTZ.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IConnection _conn;

        public UserRepository(IConnection connection)
        {
            _conn = connection;
        }


        public UserAccounts Get(string login, string pass)
        {
            try
            {
                var db = _conn.GetConnection();
                return db.QueryFirstOrDefault<UserAccounts>(Scripts.User_Auth, new { login = login, pass = pass });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserAccounts Get(int userId)
        {
            try
            {
                var db = _conn.GetConnection();
                return db.QueryFirstOrDefault<UserAccounts>(Scripts.User_GetById, new { userId = userId});
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(UserAccounts user)
        {
            try
            {
                var db = _conn.GetConnection();
                var isExecut = db.Execute(Scripts.User_NewUser, user);

                return isExecut == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
