using AutoMapper;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Mappers;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class CharacterInListService :
        BaseEntityService<IAppUnitOfWork, ICharacterInListRepository, DTO.CharacterInList, DAL.App.DTO.CharacterInList>,
        ICharacterInListService
    {
        public CharacterInListService(IAppUnitOfWork serviceUow, ICharacterInListRepository serviceRepository,
            IMapper mapper) : base(serviceUow, serviceRepository, new CharacterInListMapper(mapper))
        {
        }
    }
}