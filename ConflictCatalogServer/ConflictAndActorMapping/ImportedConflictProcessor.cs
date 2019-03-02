
using Base.RuntimeChecks;
using DataRepository.Model;
using DataRepository.Repository;
using Logging;
using Services.Parser;

namespace ConflictAndActorMapping
{
    public class ImportedConflictProcessor
    {
        private readonly IReadAll<ImportedConflictModel> importedConflictRepository;
        private readonly IParseImportedConflictSummary parser;

        public ImportedConflictProcessor(
            IReadAll<ImportedConflictModel> importedConflictRepository,
            IParseImportedConflictSummary parser)
        {
            Argument.AssertIsNotNull(importedConflictRepository, nameof(importedConflictRepository));
            Argument.AssertIsNotNull(parser, nameof(parser));

            this.importedConflictRepository = importedConflictRepository;
            this.parser = parser;
        }

        public void Process()
        {
            Logger.Log.Info("Reading imported conflicts...");
            var importedConflicts = this.importedConflictRepository.ReadAll();
            Logger.Log.Info($"{importedConflicts.Count} imported conflicts read.");

            this.parser.parseImportedConflicts(importedConflicts);
        }
    }
}
