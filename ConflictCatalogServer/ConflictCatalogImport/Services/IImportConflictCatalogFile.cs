
using DataRepository.DataAccess;

namespace ConflictCatalogImport.Services
{
    public interface IImportConflictCatalogFile
    {
        void Import(string fileName, IImportedConflictDataAccess targetRepository);
    }
}
