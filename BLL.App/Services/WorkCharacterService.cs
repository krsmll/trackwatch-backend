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
    public class WorkCharacterService : BaseEntityService<IAppUnitOfWork, IWorkCharacterRepository, DTO.WorkCharacter, DAL.App.DTO.WorkCharacter>, IWorkCharacterService
    {
        public WorkCharacterService(IAppUnitOfWork serviceUow, IWorkCharacterRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new WorkCharacterMapper(mapper))
        {
        }
    }
}