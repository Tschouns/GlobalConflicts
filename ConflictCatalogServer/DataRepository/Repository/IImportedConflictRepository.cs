using DataRepository.Model;

namespace DataRepository.Repository
{
    public interface IImportedConflictRepository : IReadAll<ImportedConflictModel>, IInsert<ImportedConflictModel>, IDeleteAll
    {
    }
}
