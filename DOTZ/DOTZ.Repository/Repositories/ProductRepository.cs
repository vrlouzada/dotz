using Dapper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.DTO;
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

        public bool Insert(Product product)
        {
            var sql = $"INSERT INTO {nameof(Product)} (Name, Description, Amount, Stock, CategoryId) Values (@name, @description, @amount, @stock, @categoryId)";

            var db = _conn.GetConnection();

            var result = db.Execute(sql, product);

            return result > 0 ? true : false;
        }

        public List<ProductDTO> GetAvailableList()
        {
            try
            {
                var sql =   $"SELECT PRD.Id, PRD.Name, PRD.Description, PRD.Amount, PRD.Stock, CT.Description as Category " +
                            $"FROM {nameof(Product)} PRD " +
                            $"INNER JOIN Category CT ON CT.Id = PRD.CategoryId " +
                            $"WHERE PRD.Stock > 0";

                var db = _conn.GetConnection();

                var result = db.Query<ProductDTO>(sql).ToList();

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
