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
    public class PersonPictureService : BaseEntityService<IAppUnitOfWork, IPersonPictureRepository, DTO.PersonPicture, DAL.App.DTO.PersonPicture>, IPersonPictureService
    {
        public PersonPictureService(IAppUnitOfWork serviceUow, IPersonPictureRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new PersonPictureMapper(mapper))
        {
        }
    }
}