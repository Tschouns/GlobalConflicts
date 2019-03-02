
using DataRepository.Model;
using System.Collections.Generic;

namespace Services.Parser
{
    public interface IParseImportedConflictSummary
    {
        IEnumerable<Conflict> ParseImportedConflicts(IEnumerable<ImportedConflictModel> importedConflictModels);
    }
}
