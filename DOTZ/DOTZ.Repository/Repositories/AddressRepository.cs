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
    public class AddressRepository : IAddressRepository
    {

        private readonly IConnection _conn;

        public AddressRepository(IConnection connection)
        {
            _conn = connection;
            
        }

        public Address Get(int id)
        {
            try
            {
                var sql = $"SELECT * FROM {nameof(Address)} WHERE Id = @id";

                var _db = _conn.GetConnection();

                return _db.QueryFirstOrDefault<Address>(sql, new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Address Get(int costumerId, string description)
        {
            try
            {
                var sql = $"SELECT * FROM {nameof(Address)} WHERE CostumerId = @costumerId and Description = @description";

                var _db = _conn.GetConnection();

                return _db.QueryFirstOrDefault<Address>(sql, new { costumerId = costumerId, description = description });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Address> GetList(int costumerId)
        {
            try
            {
                var sql = $"SELECT * FROM {nameof(Address)} WHERE CostumerId = @costumerId";

                var _db = _conn.GetConnection();

                return _db.Query<Address>(sql, new { costumerId = costumerId }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Address address)
        {
            try
            {
                var sql = $"INSERT INTO {nameof(Address)} (CostumerId, Description, Street, Number, Complement, PostalCode, Neighborhood, City, State) " +
                            $"Values (@costumerId, @description, @street, @number, @complement, @postalCode, @neighborhood, @city, @state)";

                var _db = _conn.GetConnection();

                var result = _db.Execute(sql, address);

                return result == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Address address)
        {
            try
            {
                var sql = $"UPDATE {nameof(Address)} " +
                            $"SET CostumerId = @costumerId, " +
                            $"    Description = @description, " +
                            $"    Street = @street, " +
                            $"    Number = @number, " +
                            $"    Complement = @complement, " +
                            $"    PostalCode = @postalCode, " +
                            $"    Neighborhood = @neighborhood, " +
                            $"    City = @city, " +
                            $"    State = @state " +
                            $"WHERE Id = @id";

                var _db = _conn.GetConnection();

                var result = _db.Execute(sql, address);

                return result == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
