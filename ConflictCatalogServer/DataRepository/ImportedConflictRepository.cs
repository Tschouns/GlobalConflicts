
using Base.RuntimeChecks;

namespace DataRepository
{
    public class ImportedConflictRepository : IImportedConflictRepository
    {
        public void SaveImportedConflict(ImportedConflictModel importedConflictModel)
        {
            Argument.AssertIsNotNull(importedConflictModel, nameof(importedConflictModel));
        }
    }
}
