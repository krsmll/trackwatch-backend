using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IStatusRepository : IBaseRepository<Status>, IStatusRepositoryCustom<Status>
    {
        
    }

    public interface IStatusRepositoryCustom<TEntity>
    {
        
    }
}