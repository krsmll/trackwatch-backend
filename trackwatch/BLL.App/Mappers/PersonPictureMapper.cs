using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class PersonPictureMapper : BaseMapper<BLL.App.DTO.PersonPicture, DAL.App.DTO.PersonPicture>,
        IBaseMapper<BLL.App.DTO.PersonPicture, DAL.App.DTO.PersonPicture>
    {
        public PersonPictureMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}