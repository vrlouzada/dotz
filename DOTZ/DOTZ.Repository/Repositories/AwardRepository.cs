using Dapper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using DOTZ.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

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
                var db = _conn.GetConnection();

                return db.Query<Award>(Scripts.Award_GetAll, new { costumerId = costumerId }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Award award)
        {
            try
            {
                var db = _conn.GetConnection();

                var result = db.Execute(Scripts.Award_Update, award);

                return result == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
