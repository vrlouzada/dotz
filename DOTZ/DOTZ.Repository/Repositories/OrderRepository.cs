using DOTZ.Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dapper;
using DOTZ.Domain.Entity;

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
                var sql = $"SELECT * FROM {nameof(Orders)} WHERE CostumerId = @costumerId";

                var db = _conn.GetConnection();

                return db.Query<Orders>(sql, new { costumerId = costumerId }).ToList();
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
                var sql = $"INSERT INTO {nameof(Orders)} (CostumerId, ProductId, AddressId, OrderStatusId, Amount, Date) Values (@costumerId, @productId, @addressId, @orderStatusId, @amount, @date)";

                var db = _conn.GetConnection();

                var result = db.Execute(sql, order);

                return result == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
