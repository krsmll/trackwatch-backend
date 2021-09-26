using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IGenreService : IBaseEntityService<BLLAppDTO.Genre, DALAppDTO.Genre>, IGenreRepositoryCustom<BLLAppDTO.Genre>
    {
        
    }
}