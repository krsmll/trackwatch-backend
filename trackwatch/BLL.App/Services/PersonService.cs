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
    public class PersonService : BaseEntityService<IAppUnitOfWork, IPersonRepository, DTO.Person, DAL.App.DTO.Person>, IPersonService
    {
        public PersonService(IAppUnitOfWork serviceUow, IPersonRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new PersonMapper(mapper))
        {
        }
    }
}