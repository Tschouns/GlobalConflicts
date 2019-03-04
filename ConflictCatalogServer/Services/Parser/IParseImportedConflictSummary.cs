
using DataRepository.Model;
using Services.ConflictModels;
using System.Collections.Generic;

namespace Services.Parser
{
    public interface IParseImportedConflictSummary
    {
        IEnumerable<Conflict> ParseImportedConflicts(IEnumerable<ImportedConflictModel> importedConflictModels);
    }
}
