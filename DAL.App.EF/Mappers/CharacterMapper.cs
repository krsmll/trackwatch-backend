using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class CharacterMapper : BaseMapper<DAL.App.DTO.Character, Domain.App.Character>,
        IBaseMapper<DAL.App.DTO.Character, Domain.App.Character>
    {
        public CharacterMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}