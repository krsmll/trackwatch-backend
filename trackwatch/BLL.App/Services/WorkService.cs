

using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class WorkService : BaseEntityService<IAppUnitOfWork, IWorkRepository, DTO.Work, DAL.App.DTO.Work>,
        IWorkService
    {
        public WorkService(IAppUnitOfWork serviceUow, IWorkRepository serviceRepository, IMapper mapper) : base(
            serviceUow, serviceRepository, new WorkMapper(mapper))
        {
        }

        public async Task<Work?> FirstOrDefaultNoIncludesAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            return Mapper.Map(await ServiceRepository.FirstOrDefaultNoIncludesAsync(id, userId, noTracking));
        }
    }
}