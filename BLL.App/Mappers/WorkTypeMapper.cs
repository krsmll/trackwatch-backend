using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class WorkTypeMapper : BaseMapper<BLL.App.DTO.WorkType, DAL.App.DTO.WorkType>,
        IBaseMapper<BLL.App.DTO.WorkType, DAL.App.DTO.WorkType>
    {
        public WorkTypeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}