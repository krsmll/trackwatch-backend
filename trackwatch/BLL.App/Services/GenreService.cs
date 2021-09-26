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
    public class GenreService : BaseEntityService<IAppUnitOfWork, IGenreRepository, DTO.Genre, DAL.App.DTO.Genre>, IGenreService
    {
        public GenreService(IAppUnitOfWork serviceUow, IGenreRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new GenreMapper(mapper))
        {
        }
    }
}