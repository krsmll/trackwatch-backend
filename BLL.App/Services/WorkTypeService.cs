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
    public class WorkTypeService : BaseEntityService<IAppUnitOfWork, IWorkTypeRepository, DTO.WorkType, DAL.App.DTO.WorkType>, IWorkTypeService
    {
        public WorkTypeService(IAppUnitOfWork serviceUow, IWorkTypeRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new WorkTypeMapper(mapper))
        {
        }
    }
}