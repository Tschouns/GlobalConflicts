using Base.RuntimeChecks;

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

        public void Insert(ImportedConflictRow model)
        {
            Argument.AssertIsNotNull(model, nameof(model));


        }
    }
}
