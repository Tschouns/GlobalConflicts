
using DataRepository.Model;
using Services.ConflictStructureModels;
using System.Collections.Generic;

namespace Services.Parser
{
    public interface IParseImportedConflictSummary
    {
        IEnumerable<Conflict> ParseImportedConflicts(IEnumerable<ImportedConflictModel> importedConflictModels);
    }
}
