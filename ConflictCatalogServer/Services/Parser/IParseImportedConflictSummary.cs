
using DataRepository.Model;
using System.Collections.Generic;

namespace Services.Parser
{
    public interface IParseImportedConflictSummary
    {
        void parseImportedConflicts(IEnumerable<ImportedConflictModel> importedConflictModels);
    }
}
