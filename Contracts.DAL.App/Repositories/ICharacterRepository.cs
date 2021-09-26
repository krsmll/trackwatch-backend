using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ICharacterRepository : IBaseRepository<Character>, ICharacterRepositoryCustom<Character>
    {
        
    }

    public interface ICharacterRepositoryCustom<TEntity>
    {
        
    }
}