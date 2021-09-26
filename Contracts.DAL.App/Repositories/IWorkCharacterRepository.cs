using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkCharacterRepository : IBaseRepository<WorkCharacter>, IWorkCharacterRepositoryCustom<WorkCharacter>
    {
        
    }

    public interface IWorkCharacterRepositoryCustom<TEntity>
    {
        
    }
}