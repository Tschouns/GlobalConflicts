using Base.RuntimeChecks;
using DataRepository.Model;
using DataRepository.Repository;
using Services.ConflictStructureModels;
using Services.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Services.ConflictJson
{
    public class RetrieveConflictJsonService : IRetrieveConflictJson
    {
        private readonly IReadAll<ImportedConflictModel> importedConflictRepository;
        private readonly IParseImportedConflictSummary parseImportedConflictSummaryService;

        public RetrieveConflictJsonService(
            IReadAll<ImportedConflictModel> importedConflictRepository,
            IParseImportedConflictSummary parseImportedConflictSummaryService)
        {
            Argument.AssertIsNotNull(importedConflictRepository, nameof(importedConflictRepository));
            Argument.AssertIsNotNull(parseImportedConflictSummaryService, nameof(parseImportedConflictSummaryService));

            this.importedConflictRepository = importedConflictRepository;
            this.parseImportedConflictSummaryService = parseImportedConflictSummaryService;
        }

        public string RetrieveConflictJsonString()
        {
            var importedConflicts = this.importedConflictRepository.ReadAll();
            var conflicts = this.parseImportedConflictSummaryService.ParseImportedConflicts(importedConflicts).ToList();

            var serializer = new DataContractJsonSerializer(typeof(List<Conflict>));
            var memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, conflicts);

            memoryStream.Position = 0;
            var streamReader = new StreamReader(memoryStream);
            var jsonString = streamReader.ReadToEnd();

            return jsonString;
        }
    }
}
