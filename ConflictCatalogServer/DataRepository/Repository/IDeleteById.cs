
using DataRepository.Model;

namespace DataRepository.Repository
{
    public interface IDeleteById<TModel>
        where TModel : class, IIdentifiedModel
    {
        void Delete(TModel model);
    }
}
