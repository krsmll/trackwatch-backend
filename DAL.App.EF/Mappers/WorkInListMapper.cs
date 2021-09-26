using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class WorkInListMapper : BaseMapper<DTO.WorkInList, Domain.App.WorkInList>,
        IBaseMapper<DAL.App.DTO.WorkInList, Domain.App.WorkInList>
    {
        public WorkInListMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}