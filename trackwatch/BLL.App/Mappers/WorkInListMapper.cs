using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class WorkInListMapper : BaseMapper<BLL.App.DTO.WorkInList, DAL.App.DTO.WorkInList>,
        IBaseMapper<BLL.App.DTO.WorkInList, DAL.App.DTO.WorkInList>
    {
        public WorkInListMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}