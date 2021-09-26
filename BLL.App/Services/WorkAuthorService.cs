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
    public class WorkAuthorService : BaseEntityService<IAppUnitOfWork, IWorkAuthorRepository, DTO.WorkAuthor, DAL.App.DTO.WorkAuthor>, IWorkAuthorService
    {
        public WorkAuthorService(IAppUnitOfWork serviceUow, IWorkAuthorRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new WorkAuthorMapper(mapper))
        {
        }
    }
}