using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class CoverPictureMapper : BaseMapper<BLL.App.DTO.CoverPicture, DAL.App.DTO.CoverPicture>,
        IBaseMapper<BLL.App.DTO.CoverPicture, DAL.App.DTO.CoverPicture>
    {
        public CoverPictureMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}