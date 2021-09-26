using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class WorkRelationMapper : BaseMapper<DTO.WorkRelation, Domain.App.WorkRelation>,
        IBaseMapper<DAL.App.DTO.WorkRelation, Domain.App.WorkRelation>
    {
        public WorkRelationMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}