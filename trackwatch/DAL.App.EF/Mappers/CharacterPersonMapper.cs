using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class CharacterPersonMapper : BaseMapper<DAL.App.DTO.CharacterPerson, Domain.App.CharacterPerson>,
        IBaseMapper<DAL.App.DTO.CharacterPerson, Domain.App.CharacterPerson>
    {
        public CharacterPersonMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}