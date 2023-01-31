using Dapper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using DOTZ.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DOTZ.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly IConnection _conn;

        public OrderRepository(IConnection conn)
        {
            _conn = conn;
        }


        public List<Orders> GetList(int costumerId)
        {
            try
            {
                var db = _conn.GetConnection();

                return db.Query<Orders>(Scripts.Order_GetByCostumer, new { costumerId = costumerId }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Orders order)
        {
            try
            {
                var db = _conn.GetConnection();

                var result = db.Execute(Scripts.Order_New, order);

                return result == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
