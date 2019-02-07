using DataRepository.Model;

namespace DataRepository.Repository
{
    public interface IInsert<in TModel>
        where TModel : class, IIdentifiedModel
    {
        void Insert(TModel model);
    }
}
