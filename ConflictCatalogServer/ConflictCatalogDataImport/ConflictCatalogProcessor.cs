using Base.RuntimeChecks;
using ConflictCatalogDataImport.Services;
using DataRepository.DataAccess;
using Logging;

namespace ConflictCatalogDataImport
{
    public class ConflictCatalogProcessor
    {
        private readonly IImportConflictCatalogFile importConflictCatalogFile;
        private readonly IImportedConflictDataAccess importedConflictRepository;

        public ConflictCatalogProcessor(
            IImportConflictCatalogFile importConflictCatalogFile,
            IImportedConflictDataAccess importedConflictRepository)
        {
            Argument.AssertIsNotNull(importConflictCatalogFile, nameof(importConflictCatalogFile));
            Argument.AssertIsNotNull(importedConflictRepository, nameof(importedConflictRepository));

            this.importConflictCatalogFile = importConflictCatalogFile;
            this.importedConflictRepository = importedConflictRepository;
        }

        public void ProcessCatalog(ConflictCatalogProcessorArguments arguments)
        {
            Argument.AssertIsNotNull(arguments, nameof(arguments));

            Logger.Log.Info($"Starting to process {arguments.FileName}...");

            this.importConflictCatalogFile.Import(arguments.FileName, this.importedConflictRepository);
        }
    }
}
