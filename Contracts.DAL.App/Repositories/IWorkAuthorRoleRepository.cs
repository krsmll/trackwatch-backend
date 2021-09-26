using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkAuthorRoleRepository : IBaseRepository<WorkAuthorRole>, IWorkAuthorRoleRepositoryCustom<WorkAuthorRole>
    {
        
    }

    public interface IWorkAuthorRoleRepositoryCustom<TEntity>
    {
        
    }
}