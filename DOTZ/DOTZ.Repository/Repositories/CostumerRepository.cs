using Dapper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using DOTZ.Domain.Resources;
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
                var _db = _conn.GetConnection();

                return _db.QueryFirstOrDefault<Costumer>(Scripts.Costumer_Get, new { userId = userId });
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
                var _db = _conn.GetConnection();

                var isExecut = _db.Execute(Scripts.Costumer_New, costumer);

                return isExecut == 1;
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
                var _db = _conn.GetConnection();

                var isUpdated = _db.Execute(Scripts.Costumer_Update, costumer);

                return isUpdated == 1;
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
                var _db = _conn.GetConnection();

                return _db.QueryFirstOrDefault<double>(Scripts.Costumer_GetBalance, new { UserId = userId });
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
                var _db = _conn.GetConnection();

                var result = _db.Execute(Scripts.Costumer_UpdateBalance, new { Balance = balance,  UserId = userId });

                return result == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
