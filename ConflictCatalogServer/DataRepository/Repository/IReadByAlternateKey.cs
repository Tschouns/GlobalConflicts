using Base.Result;
using DataRepository.Model;

namespace DataRepository.Repository
{
    public interface IReadByAlternateKey<TModel>
        where TModel : class, IDataModel
    {
        OptionalResult<TModel> ReadbyAlternateKey(string key);
    }
}
