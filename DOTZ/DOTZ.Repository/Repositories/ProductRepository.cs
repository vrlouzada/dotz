using Dapper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.DTO;
using DOTZ.Domain.Entity;
using DOTZ.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                var db = _conn.GetConnection();

                return db.Query<Product>(Scripts.Product_GetAll).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product Get(int id)
        {
            try
            {
                var db = _conn.GetConnection();

                return db.QueryFirstOrDefault<Product>(Scripts.Product_GetById, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateStock(int id, int stock)
        {
            try
            {
                var db = _conn.GetConnection();

                var result = db.Execute(Scripts.Product_UpdateStock, new { Stock = stock, Id = id });

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Product product)
        {
            try
            {
                var db = _conn.GetConnection();

                var result = db.Execute(Scripts.Product_NewProduct, product);

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductDTO> GetAvailableList()
        {
            try
            {
                var db = _conn.GetConnection();

                var result = db.Query<ProductDTO>(Scripts.Product_GetAvailableWithCategory).ToList();

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
