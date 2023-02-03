using DOTZ.Domain.Contracts.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DOTZ.Repository.Bases
{

    public class Connection : IConnection
    {
        private readonly IConfiguration _configuration;
        protected IDbConnection _conn;

        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IDbConnection GetConnection()
        {
            try
            {
                if (_conn == null)
                {
                    _conn = new SqlConnection(_configuration.GetConnectionString("SqlServer"));
                }
                else
                {
                    if (_conn.State == ConnectionState.Closed)
                    {
                        _conn.Open();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _conn;
        }

    }
}
