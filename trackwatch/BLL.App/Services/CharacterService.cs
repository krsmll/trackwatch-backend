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
    public class CharacterService : BaseEntityService<IAppUnitOfWork, ICharacterRepository, DTO.Character, DAL.App.DTO.Character>, ICharacterService
    {
        public CharacterService(IAppUnitOfWork serviceUow, ICharacterRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new CharacterMapper(mapper))
        {
        }
    }
}