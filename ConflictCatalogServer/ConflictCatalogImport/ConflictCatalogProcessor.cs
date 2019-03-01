using Base.RuntimeChecks;
using Services;
using DataRepository.Repository;
using Logging;

namespace ConflictCatalogImport
{
    public class ConflictCatalogProcessor
    {
        private readonly IImportConflictCatalogFile importConflictCatalogFileService;
        private readonly IImportedConflictRepository importedConflictRepository;

        public ConflictCatalogProcessor(
            IImportConflictCatalogFile importConflictCatalogFileService,
            IImportedConflictRepository importedConflictRepository)
        {
            Argument.AssertIsNotNull(importConflictCatalogFileService, nameof(importConflictCatalogFileService));
            Argument.AssertIsNotNull(importedConflictRepository, nameof(importedConflictRepository));

            this.importConflictCatalogFileService = importConflictCatalogFileService;
            this.importedConflictRepository = importedConflictRepository;
        }

        public void ProcessCatalog(ConflictCatalogProcessorArguments arguments)
        {
            Argument.AssertIsNotNull(arguments, nameof(arguments));

            Logger.Log.Info("Clearing imported conflicts...");
            this.importedConflictRepository.ClearAll();
            Logger.Log.Info("Cleared imported conflicts.");

            Logger.Log.Info($"Starting to process {arguments.FileName}...");
            this.importConflictCatalogFileService.Import(arguments.FileName, this.importedConflictRepository);
        }
    }
}
