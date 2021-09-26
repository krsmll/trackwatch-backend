using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class GenreMapper : BaseMapper<BLL.App.DTO.Genre, DAL.App.DTO.Genre>,
        IBaseMapper<BLL.App.DTO.Genre, DAL.App.DTO.Genre>
    {
        public GenreMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}