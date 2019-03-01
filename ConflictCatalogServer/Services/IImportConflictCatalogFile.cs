
using DataRepository.Model;
using DataRepository.Repository;

namespace Services
{
    public interface IImportConflictCatalogFile
    {
        void Import(string fileName, IInsert<ImportedConflictModel> targetRepository);
    }
}
