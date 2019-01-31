using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.DataAccess
{
    public interface IImportedConflictDataAccess
    {
        void Insert(ImportedConflictRow model);
    }
}
