using Base.RuntimeChecks;
using ConflictCatalogImport.Services;
using DataRepository.DataAccess;
using Logging;

namespace ConflictCatalogImport
{
    public class ConflictCatalogProcessor
    {
        private readonly IImportConflictCatalogFile importConflictCatalogFile;
        private readonly IImportedConflictRepository importedConflictRepository;

        public ConflictCatalogProcessor(
            IImportConflictCatalogFile importConflictCatalogFile,
            IImportedConflictRepository importedConflictRepository)
        {
            Argument.AssertIsNotNull(importConflictCatalogFile, nameof(importConflictCatalogFile));
            Argument.AssertIsNotNull(importedConflictRepository, nameof(importedConflictRepository));

            this.importConflictCatalogFile = importConflictCatalogFile;
            this.importedConflictRepository = importedConflictRepository;
        }

        public void ProcessCatalog(ConflictCatalogProcessorArguments arguments)
        {
            Argument.AssertIsNotNull(arguments, nameof(arguments));

            Logger.Log.Info("Clearing imported conflicts...");
            this.importedConflictRepository.ClearAll();
            Logger.Log.Info("Cleared imported conflicts.");

            Logger.Log.Info($"Starting to process {arguments.FileName}...");
            this.importConflictCatalogFile.Import(arguments.FileName, this.importedConflictRepository);
        }
    }
}
