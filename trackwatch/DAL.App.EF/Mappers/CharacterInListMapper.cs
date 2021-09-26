using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class CharacterInListMapper : BaseMapper<DAL.App.DTO.CharacterInList, Domain.App.CharacterInList>,
        IBaseMapper<DAL.App.DTO.CharacterInList, Domain.App.CharacterInList>
    {
        public CharacterInListMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}