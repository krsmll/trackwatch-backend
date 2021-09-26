using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class CharacterPictureMapper : BaseMapper<BLL.App.DTO.CharacterPicture, DAL.App.DTO.CharacterPicture>,
        IBaseMapper<BLL.App.DTO.CharacterPicture, DAL.App.DTO.CharacterPicture>
    {
        public CharacterPictureMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}