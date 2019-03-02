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
        public void parseImportedConflicts(IEnumerable<ImportedConflictModel> importedConflictModels)
        {
            Argument.AssertIsNotNull(importedConflictModels, nameof(importedConflictModels));

            Logger.Log.Info($"Parsing {importedConflictModels.Count()} imported conflicts...");

            // Set up parser rules, chain-of-command-style.
            var rule = new SidesOrNoSidesRule( );

            foreach(var importedConflict in importedConflictModels)
            {
                var builder = new ConflictBuilder();
                rule.Apply(new[] { importedConflict.Summary }, builder);
            }
        }
    }
}
