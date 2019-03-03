using Base.RuntimeChecks;
using Dapper;
using DataRepository.DbConnection;
using DataRepository.Model;
using System;
using System.Collections.Generic;

namespace DataRepository.Repository
{
    public class ImportedConflictRepository : IImportedConflictRepository
    {
        private readonly IDbConnectionProvider dbConnectionProvider;

        public ImportedConflictRepository(IDbConnectionProvider dbConnectionProvider)
        {
            Argument.AssertIsNotNull(dbConnectionProvider, nameof(dbConnectionProvider));

            this.dbConnectionProvider = dbConnectionProvider;
        }

        public IReadOnlyCollection<ImportedConflictModel> ReadAll()
        {
            var connection = this.dbConnectionProvider.GetConnection();

            var importedConflicts = connection.Query<ImportedConflictModel>(SqlCommands.ImportedConflictSelectAll);

            return importedConflicts.AsList();
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

        public int DeleteAll()
        {
            var connection = this.dbConnectionProvider.GetConnection();
            var affectedRows = connection.Execute(SqlCommands.ImportedConflictDeleteAll);

            return affectedRows;
        }
    }
}
