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
    public class RatingScaleService : BaseEntityService<IAppUnitOfWork, IRatingScaleRepository, DTO.RatingScale, DAL.App.DTO.RatingScale>, IRatingScaleService
    {
        public RatingScaleService(IAppUnitOfWork serviceUow, IRatingScaleRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new RatingScaleMapper(mapper))
        {
        }
    }
}