using DataRepository.Model;
using System.Collections.Generic;

namespace DataRepository.Repository
{
    public interface IReadAll<out TModel>
        where TModel : class, IDataModel
    {
        IReadOnlyCollection<TModel> ReadAll();
    }
}
