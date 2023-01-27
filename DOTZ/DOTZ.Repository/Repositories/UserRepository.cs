using Dapper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

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
                var sql = $"SELECT * FROM {nameof(UserAccounts)} WHERE Login = @login AND Pass = @pass";
                return db.QueryFirstOrDefault<UserAccounts>(sql, new { login = login, pass = pass });
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
                var sql = $"SELECT * FROM {nameof(UserAccounts)} WHERE Id = @userId";
                return db.QueryFirstOrDefault<UserAccounts>(sql, new { userId = userId});
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
                var isExecut = db.Execute("Insert into User (login, pass) values (@login, @pass)", user);

                return isExecut == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
