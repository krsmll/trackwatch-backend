using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class WatchListMapper : BaseMapper<BLL.App.DTO.WatchList, DAL.App.DTO.WatchList>,
        IBaseMapper<BLL.App.DTO.WatchList, DAL.App.DTO.WatchList>
    {
        public WatchListMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}