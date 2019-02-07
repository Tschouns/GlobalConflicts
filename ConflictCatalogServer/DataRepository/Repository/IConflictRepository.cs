using DataRepository.Model;

namespace DataRepository.Repository
{
    public interface IConflictRepository : IInsert<ConflictModel>, IClearAll
    {
    }
}
