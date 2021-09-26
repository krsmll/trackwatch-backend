using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ICoverPictureRepository : IBaseRepository<CoverPicture>, ICoverPictureRepositoryCustom<CoverPicture>
    {
        
    }

    public interface ICoverPictureRepositoryCustom<TEntity>
    {
        
    }
}