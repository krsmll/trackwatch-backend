using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IFormatRepository : IBaseRepository<Format>, IFormatRepositoryCustom<Format>
    {
        
    }

    public interface IFormatRepositoryCustom<TEntity>
    {
        
    }
}