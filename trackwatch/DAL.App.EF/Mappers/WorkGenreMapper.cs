using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class WorkGenreMapper : BaseMapper<DTO.WorkGenre, Domain.App.WorkGenre>,
        IBaseMapper<DAL.App.DTO.WorkGenre, Domain.App.WorkGenre>
    {
        public WorkGenreMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}