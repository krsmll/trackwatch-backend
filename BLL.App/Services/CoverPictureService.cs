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
    public class CoverPictureService : BaseEntityService<IAppUnitOfWork, ICoverPictureRepository, DTO.CoverPicture, DAL.App.DTO.CoverPicture>, ICoverPictureService
    {
        public CoverPictureService(IAppUnitOfWork serviceUow, ICoverPictureRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new CoverPictureMapper(mapper))
        {
        }
    }
}