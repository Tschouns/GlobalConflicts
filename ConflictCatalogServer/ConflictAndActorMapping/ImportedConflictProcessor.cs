
using Base.RuntimeChecks;
using DataRepository.Model;
using DataRepository.Repository;
using Logging;
using Services.Parser;
using System.Linq;

namespace ConflictAndActorMapping
{
    public class ImportedConflictProcessor
    {
        private readonly INationRepository nationsRepository;
        private readonly IReadAll<ImportedConflictModel> readAllImportedConflictsRepository;
        private readonly IParseImportedConflictSummary parser;

        public ImportedConflictProcessor(
            INationRepository nationsRepository,
            IReadAll<ImportedConflictModel> readAllImportedConflictsRepository,
            IParseImportedConflictSummary parser)
        {
            Argument.AssertIsNotNull(nationsRepository, nameof(nationsRepository));
            Argument.AssertIsNotNull(readAllImportedConflictsRepository, nameof(readAllImportedConflictsRepository));
            Argument.AssertIsNotNull(parser, nameof(parser));

            this.nationsRepository = nationsRepository;
            this.readAllImportedConflictsRepository = readAllImportedConflictsRepository;
            this.parser = parser;
        }

        public void Process()
        {
            this.CleanUpUnusedNations();
            this.ProcessImportedConflictsAndCreateNations();
        }

        private void CleanUpUnusedNations()
        {
            Logger.Log.Info("Cleaning up nations...");
            var allNations = this.nationsRepository.ReadAll();
            Logger.Log.Info($"{allNations.Count} existing nations found.");

            var unusedNations = allNations
                .Where(n => n.MapXCoord == 0 && n.MapYCoord == 0)
                .ToList();
            Logger.Log.Info($"{unusedNations.Count} existing nations without coordinates found.");

            foreach (var nation in unusedNations)
            {
                this.nationsRepository.Delete(nation);
            }

            Logger.Log.Info($"{unusedNations.Count} nations deleted.");
        }

        private void ProcessImportedConflictsAndCreateNations()
        {
            Logger.Log.Info("Reading imported conflicts...");
            var importedConflicts = this.readAllImportedConflictsRepository.ReadAll();
            Logger.Log.Info($"{importedConflicts.Count} imported conflicts read.");

            Logger.Log.Info("Parsing imported conflicts...");
            var conflicts = this.parser.ParseImportedConflicts(importedConflicts);
            var allNations = conflicts
                .SelectMany(c => c.Sides)
                .SelectMany(s => s.Actors)
                .Select(a => a.Location)
                .ToList();

            var distinctNations = allNations
                .Distinct()
                .ToList();

            Logger.Log.Info($"{distinctNations.Count} distinct nations needed.");

            Logger.Log.Info("Updating nations...");
            var existingNations = this.nationsRepository.ReadAll();
            var newNations = distinctNations
                .Where(n => !existingNations.Select(e => e.UniqueName).Contains(n))
                .Where(n => !int.TryParse(n, out int i))
                .Select(n => new NationModel
                    {
                        UniqueName = n,
                        NumberOfOccurrences = allNations.Where(m => m == n).Count(),
                    })
                .OrderBy(n => n.UniqueName)
                .ToList();

            Logger.Log.Info($"Creating {newNations.Count} new nations...");
            foreach (var newNation in newNations)
            {
                this.nationsRepository.Insert(newNation);
            }

            Logger.Log.Info($"{newNations.Count} nations created.");
        }
    }
}
