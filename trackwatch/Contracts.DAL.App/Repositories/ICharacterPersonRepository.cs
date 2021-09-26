using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ICharacterPersonRepository : IBaseRepository<CharacterPerson>, ICharacterPersonRepositoryCustom<CharacterPerson>
    {
        
    }

    public interface ICharacterPersonRepositoryCustom<TEntity>
    {
        
    }
}