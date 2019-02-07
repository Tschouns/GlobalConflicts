using DataRepository.Model;

namespace DataRepository.Repository
{
    public interface IImportedConflictRepository : IInsert<ImportedConflictModel>, IClearAll
    {
    }
}
