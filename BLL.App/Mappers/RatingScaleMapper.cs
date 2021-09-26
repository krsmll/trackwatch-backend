using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class RatingScaleMapper : BaseMapper<BLL.App.DTO.RatingScale, DAL.App.DTO.RatingScale>,
        IBaseMapper<BLL.App.DTO.RatingScale, DAL.App.DTO.RatingScale>
    {
        public RatingScaleMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}