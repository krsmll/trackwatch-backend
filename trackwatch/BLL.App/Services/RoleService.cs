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
    public class RoleService : BaseEntityService<IAppUnitOfWork, IRoleRepository, DTO.Role, DAL.App.DTO.Role>, IRoleService
    {
        public RoleService(IAppUnitOfWork serviceUow, IRoleRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new RoleMapper(mapper))
        {
        }
    }
}