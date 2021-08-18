using Dapper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DOTZ.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly IConnection _conn;

        public ProductRepository(IConnection connection)
        {
            _conn = connection;
        }

        public List<Product> GetAll()
        {
            var sql = $"SELECT * FROM {nameof(Product)} WHERE Stock > 0";

            var db = _conn.GetConnection();

            return db.Query<Product>(sql).ToList();
        }

        public Product Get(int id)
        {
            var sql = $"SELECT * FROM {nameof(Product)} WHERE Id = @id";

            var db = _conn.GetConnection();

            return db.QueryFirstOrDefault<Product>(sql, new { Id = id });
        }

        public bool UpdateStock(int id, int stock)
        {
            var sql = $"UPDATE {nameof(Product)} SET Stock = @stock WHERE Id = @id";

            var db = _conn.GetConnection();

            var result = db.Execute(sql, new { Stock = stock, Id = id });

            return result > 0 ? true : false;
        }


    }
}
