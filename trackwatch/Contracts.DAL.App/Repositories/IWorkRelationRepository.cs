using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkRelationRepository : IBaseRepository<WorkRelation>, IWorkRelationRepositoryCustom<WorkRelation>
    {
        
    }

    public interface IWorkRelationRepositoryCustom<TEntity>
    {
        
    }
}