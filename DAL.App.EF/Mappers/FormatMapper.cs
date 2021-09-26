using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class FormatMapper : BaseMapper<DAL.App.DTO.Format, Domain.App.Format>,
        IBaseMapper<DAL.App.DTO.Format, Domain.App.Format>
    {
        public FormatMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}