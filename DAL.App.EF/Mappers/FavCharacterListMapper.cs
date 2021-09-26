using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class FavCharacterListMapper : BaseMapper<DAL.App.DTO.FavCharacterList, Domain.App.FavCharacterList>,
        IBaseMapper<DAL.App.DTO.FavCharacterList, Domain.App.FavCharacterList>
    {
        public FavCharacterListMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}