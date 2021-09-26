using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class CharacterMapper : BaseMapper<BLL.App.DTO.Character, DAL.App.DTO.Character>,
        IBaseMapper<BLL.App.DTO.Character, DAL.App.DTO.Character>
    {
        public CharacterMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}