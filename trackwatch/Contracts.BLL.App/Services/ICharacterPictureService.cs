using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface ICharacterPictureService : IBaseEntityService<BLLAppDTO.CharacterPicture, DALAppDTO.CharacterPicture>, ICharacterPictureRepositoryCustom<BLLAppDTO.CharacterPicture>
    {
        
    }
}