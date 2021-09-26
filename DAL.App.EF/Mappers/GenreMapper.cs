using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class GenreMapper : BaseMapper<DAL.App.DTO.Genre, Domain.App.Genre>,
        IBaseMapper<DAL.App.DTO.Genre, Domain.App.Genre>
    {
        public GenreMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}