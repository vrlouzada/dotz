using Dapper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using DOTZ.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

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
                var _db = _conn.GetConnection();

                return _db.QueryFirstOrDefault<Address>(Scripts.Address_GetById, new { id = id });
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
                var _db = _conn.GetConnection();

                return _db.QueryFirstOrDefault<Address>(Scripts.Address_Get, new { costumerId = costumerId, description = description });
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
                var _db = _conn.GetConnection();

                return _db.Query<Address>(Scripts.Address_GetAll, new { costumerId = costumerId }).ToList();
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
                var _db = _conn.GetConnection();

                var result = _db.Execute(Scripts.Address_New, address);

                return result == 1;
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
                var _db = _conn.GetConnection();

                var result = _db.Execute(Scripts.Address_Update, address);

                return result == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
