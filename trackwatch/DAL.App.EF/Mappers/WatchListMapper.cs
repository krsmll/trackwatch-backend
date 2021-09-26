using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class WatchListMapper : BaseMapper<DAL.App.DTO.WatchList, Domain.App.WatchList>,
        IBaseMapper<DAL.App.DTO.WatchList, Domain.App.WatchList>
    {
        public WatchListMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}