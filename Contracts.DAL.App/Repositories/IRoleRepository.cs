using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>, IRoleRepositoryCustom<Role>
    {
        
    }

    public interface IRoleRepositoryCustom<TEntity>
    {
        
    }
}