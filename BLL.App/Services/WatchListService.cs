using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class WatchListService : BaseEntityService<IAppUnitOfWork, IWatchListRepository, DTO.WatchList, DAL.App.DTO.WatchList>, IWatchListService
    {
        public WatchListService(IAppUnitOfWork serviceUow, IWatchListRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new WatchListMapper(mapper))
        {
        }

        public async Task<WatchList?> FirstOrDefaultUserAsync(string username, Guid userId = default, bool noTracking = true)
        {
            return Mapper.Map(await ServiceRepository.FirstOrDefaultUserAsync(username, userId, noTracking));
        }
    }
}