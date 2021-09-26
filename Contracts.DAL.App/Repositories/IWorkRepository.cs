using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkRepository : IBaseRepository<Work>, IWorkRepositoryCustom<Work>
    {
    }

    public interface IWorkRepositoryCustom<TEntity>
    {
        Task<TEntity?> FirstOrDefaultNoIncludesAsync(Guid id, Guid userId = default, bool noTracking = true);
    }
}