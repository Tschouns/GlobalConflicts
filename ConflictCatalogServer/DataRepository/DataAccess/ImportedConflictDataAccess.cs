using Base.RuntimeChecks;
using Dapper;
using System;

namespace DataRepository.DataAccess
{
    public class ImportedConflictDataAccess : IImportedConflictDataAccess
    {
        private readonly IDbConnectionProvider dbConnectionProvider;

        public ImportedConflictDataAccess(IDbConnectionProvider dbConnectionProvider)
        {
            Argument.AssertIsNotNull(dbConnectionProvider, nameof(dbConnectionProvider));

            this.dbConnectionProvider = dbConnectionProvider;
        }

        public void Insert(ImportedConflictModel model)
        {
            Argument.AssertIsNotNull(model, nameof(model));
            model.AssertIsNotPersisted();

            var connection = this.dbConnectionProvider.GetConnection();
            var affectedRows = connection.Execute(SqlCommands.ImportedConflictInsert, model);

            if (affectedRows != 1)
            {
                throw new InvalidOperationException("The row could not be inserted!");
            }
        }
    }
}
