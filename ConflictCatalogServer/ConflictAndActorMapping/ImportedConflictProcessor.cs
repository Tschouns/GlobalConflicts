
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


            ////Logger.Log.Info("Reading imported conflicts...");
            ////var importedConflicts = this.readAllImportedConflictsRepository.ReadAll();
            ////Logger.Log.Info($"{importedConflicts.Count} imported conflicts read.");

            ////var conflicts = this.parser.ParseImportedConflicts(importedConflicts);
            ////var actors = conflicts
            ////    .SelectMany(c => c.Sides)
            ////    .SelectMany(s => s.Actors)
            ////    .ToList();

            ////Logger.Log.Info($"All: {actors.Count}");

            ////var uniqueActors = actors.Select(a => a.FullName).Distinct().ToList();
            ////Logger.Log.Info($"Unique actors: {uniqueActors.Count}");

            ////var uniqueLocations = actors
            ////    .Select(a => a.Location)
            ////    .Where(l => !int.TryParse(l, out int n))
            ////    .Distinct().ToList();

            ////Logger.Log.Info($"Unique locations: {uniqueLocations.Count}");
            ////Logger.Log.Info("");

            ////uniqueLocations.Sort();

            ////foreach (var location in uniqueLocations)
            ////{
            ////    Logger.Log.Info(location);
            ////}




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
            var nations = conflicts
                .SelectMany(c => c.Sides)
                .SelectMany(s => s.Actors)
                .Select(a => a.Location)
                .Distinct()
                .ToList();

            Logger.Log.Info($"{nations.Count} distinct nations needed.");

            Logger.Log.Info("Updating nations...");
            var existingNations = this.nationsRepository.ReadAll();
            var newNations = nations
                .Where(n => !existingNations.Select(e => e.UniqueName).Contains(n))
                .ToList();

            Logger.Log.Info($"Creating {newNations.Count} new nations...");
            foreach (var newNation in newNations)
            {
                this.nationsRepository.Insert(new NationModel { UniqueName = newNation });
            }
        }
    }
}
