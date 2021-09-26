using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IRatingScaleRepository : IBaseRepository<RatingScale>, IRatingScaleRepositoryCustom<RatingScale>
    {
        
    }

    public interface IRatingScaleRepositoryCustom<TEntity>
    {
        
    }
}