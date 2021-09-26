using AutoMapper;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class WorkInListService :
        BaseEntityService<IAppUnitOfWork, IWorkInListRepository, DTO.WorkInList, DAL.App.DTO.WorkInList>,
        IWorkInListService
    {
        public WorkInListService(IAppUnitOfWork serviceUow, IWorkInListRepository serviceRepository, IMapper mapper) :
            base(serviceUow, serviceRepository, new WorkInListMapper(mapper))
        {
        }
    }
}