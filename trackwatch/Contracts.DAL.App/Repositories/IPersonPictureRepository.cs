using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPersonPictureRepository : IBaseRepository<PersonPicture>, IPersonPictureRepositoryCustom<PersonPicture>
    {
        
    }

    public interface IPersonPictureRepositoryCustom<TEntity>
    {
        
    }
}