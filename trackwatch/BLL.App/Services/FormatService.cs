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
    public class FormatService : BaseEntityService<IAppUnitOfWork, IFormatRepository, DTO.Format, DAL.App.DTO.Format>, IFormatService
    {
        public FormatService(IAppUnitOfWork serviceUow, IFormatRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new FormatMapper(mapper))
        {
        }
    }
}