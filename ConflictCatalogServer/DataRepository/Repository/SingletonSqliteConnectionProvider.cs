using Base.RuntimeChecks;
using System.Data;
using System.Data.SQLite;

namespace DataRepository.Repository
{
    public class SingletonSqliteConnectionProvider : IDbConnectionProvider
    {
        private readonly string connectionString;
        private IDbConnection sqlConnection;
        
        public SingletonSqliteConnectionProvider(string connectionString)
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
                this.sqlConnection = new SQLiteConnection(this.connectionString);
                this.sqlConnection.Open();            }

            return this.sqlConnection;
        }
    }
}
