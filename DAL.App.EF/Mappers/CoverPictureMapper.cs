using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class CoverPictureMapper : BaseMapper<DAL.App.DTO.CoverPicture, Domain.App.CoverPicture>,
        IBaseMapper<DAL.App.DTO.CoverPicture, Domain.App.CoverPicture>
    {
        public CoverPictureMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}