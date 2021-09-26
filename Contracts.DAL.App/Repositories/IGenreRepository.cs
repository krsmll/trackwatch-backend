using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IGenreRepository : IBaseRepository<Genre>, IGenreRepositoryCustom<Genre>
    {
        
    }

    public interface IGenreRepositoryCustom<TEntity>
    {
        
    }
}