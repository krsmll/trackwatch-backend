using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ICharacterInListRepository : IBaseRepository<CharacterInList>, ICharacterInListRepositoryCustom<CharacterInList>
    {
        
    }
    
    public interface ICharacterInListRepositoryCustom<TEntity>
    {
        
    }
}