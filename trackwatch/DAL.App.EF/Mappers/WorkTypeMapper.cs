using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class WorkTypeMapper : BaseMapper<DAL.App.DTO.WorkType, Domain.App.WorkType>,
        IBaseMapper<DAL.App.DTO.WorkType, Domain.App.WorkType>
    {
        public WorkTypeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}