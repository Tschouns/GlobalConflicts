
using DataRepository.Model;
using Services.ConflictStructure;
using System.Collections.Generic;

namespace Services.Parser
{
    public interface IParseImportedConflictSummary
    {
        IEnumerable<ConflictData> ParseImportedConflicts(IEnumerable<ImportedConflictModel> importedConflictModels);
    }
}
