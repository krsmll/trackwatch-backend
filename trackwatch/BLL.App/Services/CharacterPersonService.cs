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
    public class CharacterPersonService : BaseEntityService<IAppUnitOfWork, ICharacterPersonRepository, DTO.CharacterPerson, DAL.App.DTO.CharacterPerson>, ICharacterPersonService
    {
        public CharacterPersonService(IAppUnitOfWork serviceUow, ICharacterPersonRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new CharacterPersonMapper(mapper))
        {
        }
    }
}