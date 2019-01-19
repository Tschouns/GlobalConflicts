using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository
{
    public interface IImportedConflictRepository
    {
        void SaveImportedConflict(ImportedConflictModel importedConflictModel);
    }
}
