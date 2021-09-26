using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkInListRepository : IBaseRepository<WorkInList>, IWorkInListRepositoryCustom<WorkInList>
    {
        
    }

    public interface IWorkInListRepositoryCustom<TEntity>
    {
        
    }
}