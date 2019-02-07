
using System.Data;

namespace DataRepository.DbConnection
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
