
using DataRepository.Repository;

namespace ConflictCatalogImport.Services
{
    public interface IImportConflictCatalogFile
    {
        void Import(string fileName, IImportedConflictRepository targetRepository);
    }
}
