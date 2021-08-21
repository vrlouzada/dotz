using System.Data;

namespace DOTZ.Domain.Contracts.Repository
{
    public interface IConnection
    {
        IDbConnection GetConnection();
    }
}
