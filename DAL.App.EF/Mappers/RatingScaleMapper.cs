using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class RatingScaleMapper : BaseMapper<DAL.App.DTO.RatingScale, Domain.App.RatingScale>,
        IBaseMapper<DAL.App.DTO.RatingScale, Domain.App.RatingScale>
    {
        public RatingScaleMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}