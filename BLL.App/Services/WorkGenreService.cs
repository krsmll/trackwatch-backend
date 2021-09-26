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
    public class WorkGenreService : BaseEntityService<IAppUnitOfWork, IWorkGenreRepository, DTO.WorkGenre, DAL.App.DTO.WorkGenre>, IWorkGenreService
    {
        public WorkGenreService(IAppUnitOfWork serviceUow, IWorkGenreRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new WorkGenreMapper(mapper))
        {
        }
    }
}