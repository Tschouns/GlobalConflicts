
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

            var conflicts = this.parser.ParseImportedConflicts(importedConflicts);

            var actors = conflicts
                .SelectMany(c => c.Sides)
                .SelectMany(s => s.Actors)
                .ToList();

            Logger.Log.Info($"All: {actors.Count}");

            var uniqueActors = actors.Select(a => a.FullName).Distinct().ToList();
            Logger.Log.Info($"Unique actors: {uniqueActors.Count}");

            var uniqueLocations = actors
                .Select(a => a.Location)
                .Where(l => !int.TryParse(l, out int n))
                .Distinct().ToList();

            Logger.Log.Info($"Unique locations: {uniqueLocations.Count}");
            Logger.Log.Info("");

            uniqueLocations.Sort();

            foreach (var location in uniqueLocations)
            {
                Logger.Log.Info(location);
            }

            ////foreach(var c in conflicts)
            ////{
            ////    Logger.Log.Info("----------------------------------------------");
            ////    Logger.Log.Info("Summary: " + c.Summary);
            ////    foreach (var s in c.Sides)
            ////    {
            ////        Logger.Log.Info("    >>>");

            ////        foreach (var a in s.Actors)
            ////        {
            ////            Logger.Log.Info("    - " + a);
            ////        }

            ////        Logger.Log.Info("");
            ////    }
            ////}
        }
    }
}
