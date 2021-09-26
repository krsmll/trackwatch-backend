using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class WorkMapper : BaseMapper<BLL.App.DTO.Work, DAL.App.DTO.Work>,
        IBaseMapper<BLL.App.DTO.Work, DAL.App.DTO.Work>
    {
        public WorkMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}