
using DataRepository.Repository;

namespace Services
{
    public interface IImportConflictCatalogFile
    {
        void Import(string fileName, IImportedConflictRepository targetRepository);
    }
}
