using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class WorkCharacterMapper : BaseMapper<BLL.App.DTO.WorkCharacter, DAL.App.DTO.WorkCharacter>,
        IBaseMapper<BLL.App.DTO.WorkCharacter, DAL.App.DTO.WorkCharacter>
    {
        public WorkCharacterMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}