
using System.Data;

namespace DataRepository.DataAccess
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
