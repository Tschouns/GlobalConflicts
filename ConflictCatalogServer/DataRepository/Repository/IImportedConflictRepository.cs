using DataRepository.Model;

namespace DataRepository.Repository
{
    public interface IImportedConflictRepository
    {
        void Insert(ImportedConflictModel model);
        int ClearAll();
    }
}
