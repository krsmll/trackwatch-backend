using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class CharacterInListMapper : BaseMapper<BLL.App.DTO.CharacterInList, DAL.App.DTO.CharacterInList>,
        IBaseMapper<BLL.App.DTO.CharacterInList, DAL.App.DTO.CharacterInList>
    {
        public CharacterInListMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}