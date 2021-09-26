using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkTypeRepository : IBaseRepository<WorkType>, IWorkTypeRepositoryCustom<WorkType>
    {
        
    }
    
    public interface IWorkTypeRepositoryCustom<TEntity>
    {
        
    }
}