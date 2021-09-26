using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class FormatMapper : BaseMapper<BLL.App.DTO.Format, DAL.App.DTO.Format>,
        IBaseMapper<BLL.App.DTO.Format, DAL.App.DTO.Format>
    {
        public FormatMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}