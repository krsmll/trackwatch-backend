using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkAuthorRepository : IBaseRepository<WorkAuthor>, IWorkAuthorRepositoryCustom<WorkAuthor>
    {
        
    }

    public interface IWorkAuthorRepositoryCustom<TEntity>
    {
        
    }
}