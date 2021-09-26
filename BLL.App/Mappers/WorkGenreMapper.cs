using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class WorkGenreMapper : BaseMapper<BLL.App.DTO.WorkGenre, DAL.App.DTO.WorkGenre>,
        IBaseMapper<BLL.App.DTO.WorkGenre, DAL.App.DTO.WorkGenre>
    {
        public WorkGenreMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}