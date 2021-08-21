using Dapper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DOTZ.Repository.Repositories
{
    public class CostumerRepository : ICostumerRepository
    {
        private readonly IConnection _conn;

        public CostumerRepository(IConnection connection)
        {
            _conn = connection;
        }


        public Costumer Get(int userId)
        {
            try
            {
                var sql = $"SELECT * FROM {nameof(Costumer)} WHERE UserId = @userId";

                var _db = _conn.GetConnection();

                return _db.QueryFirstOrDefault<Costumer>(sql, new { userId = userId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Costumer costumer)
        {
            try
            {
                var sql = $"INSERT INTO {nameof(Costumer)} (UserId, FirstName, LastName) VALUES (@userId, @firstName, @lastName)";

                var _db = _conn.GetConnection();

                var isExecut = _db.Execute(sql, costumer);

                return isExecut == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Costumer costumer)
        {
            try
            {
                var sql = $"UPDATE {nameof(Costumer)} SET FirstName = @firstName, LastName = @lastName WHERE UserId = @userId";

                var _db = _conn.GetConnection();

                var isUpdated = _db.Execute(sql, costumer);

                return isUpdated == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double GetBalance(int userId)
        {
            try
            {
                var sql = $"SELECT Balance FROM {nameof(Costumer)} WHERE UserId = @userId";

                var _db = _conn.GetConnection();

                return _db.QueryFirstOrDefault<double>(sql, new { UserId = userId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateBalance(int userId, double balance)
        {
            try
            {
                var sql = $"UPDATE {nameof(Costumer)} SET Balance = @balance WHERE UserId = @userId";

                var _db = _conn.GetConnection();

                var result = _db.Execute(sql, new { Balance = balance,  UserId = userId });

                return result == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
