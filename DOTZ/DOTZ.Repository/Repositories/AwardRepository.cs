using Dapper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOTZ.Repository.Repositories
{
    public class AwardRepository : IAwardRepository
    {

        private readonly IConnection _conn;

        public AwardRepository(IConnection conn)
        {
            _conn = conn;
        }


        public List<Award> GetList(int costumerId)
        {
            try
            {
                var sql = $"SELECT * FROM {nameof(Award)} WHERE CostumerId = @costumerId";

                var db = _conn.GetConnection();

                return db.Query<Award>(sql, new { costumerId = costumerId }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
