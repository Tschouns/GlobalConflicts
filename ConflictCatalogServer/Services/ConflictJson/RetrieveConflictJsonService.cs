using Base.RuntimeChecks;
using DataRepository.Model;
using DataRepository.Repository;
using Services.ConflictJson.JsonModels;
using Services.ConflictStructure;
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
        private readonly IReadAll<NationModel> nationRepository;
        private readonly IParseImportedConflictSummary parseImportedConflictSummaryService;

        public RetrieveConflictJsonService(
            IReadAll<ImportedConflictModel> importedConflictRepository,
            IReadAll<NationModel> nationRepository,
            IParseImportedConflictSummary parseImportedConflictSummaryService)
        {
            Argument.AssertIsNotNull(importedConflictRepository, nameof(importedConflictRepository));
            Argument.AssertIsNotNull(nationRepository, nameof(nationRepository));
            Argument.AssertIsNotNull(parseImportedConflictSummaryService, nameof(parseImportedConflictSummaryService));

            this.importedConflictRepository = importedConflictRepository;
            this.nationRepository = nationRepository;
            this.parseImportedConflictSummaryService = parseImportedConflictSummaryService;
        }

        public string RetrieveConflictJsonString()
        {
            var importedConflicts = this.importedConflictRepository.ReadAll();
            var nations = this.nationRepository.ReadAll();
            var conflicts = this.parseImportedConflictSummaryService.ParseImportedConflicts(importedConflicts).ToList();
            var jsonConflicts = MapToJsonConflicts(conflicts, nations);

            var serializer = new DataContractJsonSerializer(typeof(List<Conflict>));
            var memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, jsonConflicts);

            memoryStream.Position = 0;
            var streamReader = new StreamReader(memoryStream);
            var jsonString = streamReader.ReadToEnd();

            return jsonString;
        }

        private List<Conflict> MapToJsonConflicts(IEnumerable<ConflictData> conflicts, IEnumerable<NationModel> nations)
        {
            Argument.AssertIsNotNull(conflicts, nameof(conflicts));
            Argument.AssertIsNotNull(nations, nameof(nations));

            var knownNations = nations
                .Where(n => n.MapXCoord != 0 && n.MapYCoord != 0)
                .ToList();

            var jsonConflicts = new List<Conflict>();

            foreach (var conflict in conflicts)
            {
                var actors = conflict.Sides.SelectMany(s => s.Actors).ToList(); ;

                // Create a conflict (which may or may not be added)
                var jsonConflict = new Conflict
                {
                    CommonName = conflict.CommonName,
                    Summary = conflict.Summary,
                    StartYear = conflict.StartYear,
                    EndYear = conflict.EndYear,
                    NumberOfFatalities = conflict.NumberOfFatalities,
                };

                foreach (var actor in actors)
                {
                    var correspondingNation = knownNations.Where(n => n.UniqueName == actor.Location).SingleOrDefault();
                    if (correspondingNation != null)
                    {
                        jsonConflict.Actors.Add(new Actor
                        {
                            Name = actor.FullName,
                            PosX = correspondingNation.MapXCoord,
                            PosY = correspondingNation.MapYCoord,
                        });
                    }
                }

                // We only add the conflict if it has known actors.
                if (jsonConflict.Actors.Any())
                {
                    // Interpolate the conflicts position, using the known actos' positions.
                    jsonConflict.PosX = jsonConflict.Actors.Sum(a => a.PosX) / jsonConflict.Actors.Count;
                    jsonConflict.PosY = jsonConflict.Actors.Sum(a => a.PosY) / jsonConflict.Actors.Count;

                    jsonConflicts.Add(jsonConflict);
                }
            }

            return jsonConflicts;
        }
    }
}
