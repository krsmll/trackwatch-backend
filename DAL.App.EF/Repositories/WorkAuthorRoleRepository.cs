using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkAuthorRoleRepository : BaseRepository<DTO.WorkAuthorRole, Domain.App.WorkAuthorRole, AppDbContext>,
        IWorkAuthorRoleRepository
    {
        public WorkAuthorRoleRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new WorkAuthorRoleMapper(mapper))
        {
        }
        
        public override async Task<IEnumerable<DTO.WorkAuthorRole>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Include(a => a.WorkAuthor)
                .Include(a => a.Role)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.WorkAuthorRole?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Include(a => a.WorkAuthor)
                .Include(a => a.Role)
                .Select(x => Mapper.Map(x));
            
            var res = await resQuery.FirstOrDefaultAsync(e => e!.Id.Equals(id));

            return res!;
        }
    }
}