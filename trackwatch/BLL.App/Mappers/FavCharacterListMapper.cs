using AutoMapper;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class FavCharacterListMapper : BaseMapper<BLL.App.DTO.FavCharacterList, DAL.App.DTO.FavCharacterList>,
        IBaseMapper<BLL.App.DTO.FavCharacterList, DAL.App.DTO.FavCharacterList>
    {
        public FavCharacterListMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}