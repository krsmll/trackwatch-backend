using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class WorkMapper : BaseMapper<DTO.Work, Domain.App.Work>,
        IBaseMapper<DAL.App.DTO.Work, Domain.App.Work>
    {
        public WorkMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}