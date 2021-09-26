using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class RoleRepository : BaseRepository<DTO.Role, Domain.App.Role, AppDbContext>,
        IRoleRepository
    {
        public RoleRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new RoleMapper(mapper))
        {
        }
        
        public override async Task<IEnumerable<DTO.Role>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Include(a => a.WorkAuthors)
                .ThenInclude(a => a.WorkAuthor)
                    .ThenInclude(a => a!.Person)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.Role?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Include(a => a.WorkAuthors)
                .ThenInclude(a => a.WorkAuthor)
                    .ThenInclude(a => a!.Person)
                .AsEnumerable()
                .Select(x => Mapper.Map(x));
            
            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));

            return res!;
        }
    }
}