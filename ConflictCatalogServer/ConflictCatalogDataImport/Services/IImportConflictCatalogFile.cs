
using DataRepository.DataAccess;

namespace ConflictCatalogDataImport.Services
{
    public interface IImportConflictCatalogFile
    {
        void Import(string fileName, IImportedConflictDataAccess targetRepository);
    }
}
