using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.DataAccess
{
    public interface IImportedConflictRepository
    {
        void Insert(ImportedConflictModel model);
        int ClearAll();
    }
}
