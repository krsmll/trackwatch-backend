using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class WorkCharacterMapper : BaseMapper<DAL.App.DTO.WorkCharacter, Domain.App.WorkCharacter>,
        IBaseMapper<DAL.App.DTO.WorkCharacter, Domain.App.WorkCharacter>
    {
        public WorkCharacterMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}