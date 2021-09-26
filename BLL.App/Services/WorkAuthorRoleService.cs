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
    public class WorkAuthorRoleService : BaseEntityService<IAppUnitOfWork, IWorkAuthorRoleRepository, DTO.WorkAuthorRole, DAL.App.DTO.WorkAuthorRole>, IWorkAuthorRoleService
    {
        public WorkAuthorRoleService(IAppUnitOfWork serviceUow, IWorkAuthorRoleRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new WorkAuthorRoleMapper(mapper))
        {
        }
    }
}