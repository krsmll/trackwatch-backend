using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class StatusMapper : BaseMapper<DAL.App.DTO.Status, Domain.App.Status>,
        IBaseMapper<DAL.App.DTO.Status, Domain.App.Status>
    {
        public StatusMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}