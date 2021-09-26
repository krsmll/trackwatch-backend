using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class WorkRelationMapper : BaseMapper<BLL.App.DTO.WorkRelation, DAL.App.DTO.WorkRelation>,
        IBaseMapper<BLL.App.DTO.WorkRelation, DAL.App.DTO.WorkRelation>
    {
        public WorkRelationMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}