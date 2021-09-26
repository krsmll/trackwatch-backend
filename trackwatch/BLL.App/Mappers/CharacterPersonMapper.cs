using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class CharacterPersonMapper : BaseMapper<BLL.App.DTO.CharacterPerson, DAL.App.DTO.CharacterPerson>,
        IBaseMapper<BLL.App.DTO.CharacterPerson, DAL.App.DTO.CharacterPerson>
    {
        public CharacterPersonMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}