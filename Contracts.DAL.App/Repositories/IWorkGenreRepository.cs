using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkGenreRepository : IBaseRepository<WorkGenre>, IWorkGenreRepositoryCustom<WorkGenre>
    {
        
    }

    public interface IWorkGenreRepositoryCustom<TEntity>
    {
        
    }
}