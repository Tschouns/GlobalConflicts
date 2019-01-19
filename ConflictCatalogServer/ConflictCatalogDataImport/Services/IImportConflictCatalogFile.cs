
using DataRepository;

namespace ConflictCatalogDataImport.Services
{
    public interface IImportConflictCatalogFile
    {
        void Import(string fileName, IImportedConflictRepository targetRepository);
    }
}
