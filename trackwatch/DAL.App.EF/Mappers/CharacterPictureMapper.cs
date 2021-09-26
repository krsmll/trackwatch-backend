using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class CharacterPictureMapper : BaseMapper<DAL.App.DTO.CharacterPicture, Domain.App.CharacterPicture>,
        IBaseMapper<DAL.App.DTO.CharacterPicture, Domain.App.CharacterPicture>
    {
        public CharacterPictureMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}