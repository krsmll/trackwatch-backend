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
    public class CharacterPictureService : BaseEntityService<IAppUnitOfWork, ICharacterPictureRepository, DTO.CharacterPicture, DAL.App.DTO.CharacterPicture>, ICharacterPictureService
    {
        public CharacterPictureService(IAppUnitOfWork serviceUow, ICharacterPictureRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new CharacterPictureMapper(mapper))
        {
        }
    }
}