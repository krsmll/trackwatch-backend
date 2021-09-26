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
    public class FavCharacterListService : BaseEntityService<IAppUnitOfWork, IFavCharacterListRepository, DTO.FavCharacterList, DAL.App.DTO.FavCharacterList>, IFavCharacterListService
    {
        public FavCharacterListService(IAppUnitOfWork serviceUow, IFavCharacterListRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new FavCharacterListMapper(mapper))
        {
        }

        public async Task<FavCharacterList?> FirstOrDefaultUserAsync(string username, Guid userId = default, bool noTracking = true)
        {
            return Mapper.Map(await ServiceRepository.FirstOrDefaultUserAsync(username, userId, noTracking));
        }
    }
}