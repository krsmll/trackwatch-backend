using AutoMapper;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class WorkRelationService :
        BaseEntityService<IAppUnitOfWork, IWorkRelationRepository, DTO.WorkRelation, DAL.App.DTO.WorkRelation>,
        IWorkRelationService
    {
        public WorkRelationService(IAppUnitOfWork serviceUow, IWorkRelationRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new WorkRelationMapper(mapper))
        {
        }
    }
}