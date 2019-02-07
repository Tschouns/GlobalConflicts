
using System.Data;

namespace DataRepository.Repository
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
