using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class PersonPictureMapper : BaseMapper<DAL.App.DTO.PersonPicture, Domain.App.PersonPicture>,
        IBaseMapper<DAL.App.DTO.PersonPicture, Domain.App.PersonPicture>
    {
        public PersonPictureMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}