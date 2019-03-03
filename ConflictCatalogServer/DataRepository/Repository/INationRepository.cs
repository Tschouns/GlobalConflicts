using DataRepository.Model;

namespace DataRepository.Repository
{
    public interface INationRepository : IReadAll<NationModel>, IReadByAlternateKey<NationModel>, IInsert<NationModel>, IDeleteById<NationModel>
    {
    }
}
