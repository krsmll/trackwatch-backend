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
    public class StatusService : BaseEntityService<IAppUnitOfWork, IStatusRepository, DTO.Status, DAL.App.DTO.Status>, IStatusService
    {
        public StatusService(IAppUnitOfWork serviceUow, IStatusRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new StatusMapper(mapper))
        {
        }
    }
}