using Base.RuntimeChecks;
using System.Data;
using System.Data.SqlClient;

namespace DataRepository.DataAccess
{
    public class SingletonSqlConnectionProvider : IDbConnectionProvider
    {
        private readonly string connectionString;
        private IDbConnection sqlConnection;
        
        public SingletonSqlConnectionProvider(string connectionString)
        {
            Argument.AssertIsNotNull(connectionString, nameof(connectionString));

            this.connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            if (sqlConnection == null ||
                sqlConnection.State == ConnectionState.Closed ||
                sqlConnection.State == ConnectionState.Broken)
            {
                this.sqlConnection = new SqlConnection(this.connectionString);
            }

            return this.sqlConnection;
        }
    }
}
