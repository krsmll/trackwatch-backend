using System;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IFavCharacterListRepository : IBaseRepository<FavCharacterList>, IFavCharacterListRepositoryCustom<FavCharacterList>
    {
        
    }

    public interface IFavCharacterListRepositoryCustom<TEntity>
    {
        Task<TEntity?>  FirstOrDefaultUserAsync(string username, Guid userId = default, bool noTracking = true);  
    }
}