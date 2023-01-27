using DOTZ.Domain.Contracts.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DOTZ.Repository.Bases
{

    public class Connection : IConnection
    {

        private IDbConnection _conn;
        //private const string CONNEXTION = "Server=127.0.0.1;Database=dotz;User Id=local;Password=@local2021;";
        private const string CONNEXTION = "Server=vrldbserver.database.windows.net;Database=dotz;Uid=DeveloperAuth;Pwd=@local2021;";

        public Connection()
        {

        }


        public IDbConnection GetConnection()
        {
            try
            {
                if (_conn == null)
                {
                    _conn = new SqlConnection(CONNEXTION);
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
