﻿using Base.RuntimeChecks;
using ConflictCatalogDataImport.Services;
using DataRepository;
using Logging;

namespace ConflictCatalogDataImport
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

            Logger.Log.Info($"Starting to process {arguments.FileName}...");

            this.importConflictCatalogFile.Import(arguments.FileName, null);
        }
    }
}
