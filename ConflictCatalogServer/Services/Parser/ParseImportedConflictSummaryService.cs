using Base.RuntimeChecks;
using DataRepository.Model;
using Logging;
using Services.Parser.Builder;
using Services.Parser.Rules;
using System.Collections.Generic;
using System.Linq;

namespace Services.Parser
{
    public class ParseImportedConflictSummaryService : IParseImportedConflictSummary
    {
        public IEnumerable<Conflict> ParseImportedConflicts(IEnumerable<ImportedConflictModel> importedConflictModels)
        {
            Argument.AssertIsNotNull(importedConflictModels, nameof(importedConflictModels));

            Logger.Log.Info($"Parsing {importedConflictModels.Count()} imported conflicts...");

            // Set up parser rules, chain-of-command-style.
            var rule = new RemoveNumericBlocksAtTheEndRule(new SidesOrNoSidesRule(
                    new SplitByDashIntoSeparateSides(new SplitByCommaIntoActors()),
                    new SplitByCommaIntoSeparateSides(new SplitByCommaIntoActors())));

            var conflicts = new List<Conflict>();
            foreach(var importedConflict in importedConflictModels)
            {
                var builder = new ConflictBuilder();
                rule.Apply(importedConflict.Summary , builder);

                var conflict = builder.GetConflict();
                conflict.Summary = importedConflict.Summary;

                conflicts.Add(conflict);
            }

            return conflicts;
        }
    }
}
