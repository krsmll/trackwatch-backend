using System;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IWatchListRepository : IBaseRepository<WatchList>, IWatchListRepositoryCustom<WatchList>
    {
        
    }

    public interface IWatchListRepositoryCustom<TEntity>
    {
        Task<TEntity?>  FirstOrDefaultUserAsync(string username, Guid userId = default, bool noTracking = true);
    }
}