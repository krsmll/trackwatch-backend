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
    public class WorkTypeRepository : BaseRepository<DAL.App.DTO.WorkType, Domain.App.WorkType, AppDbContext>, IWorkTypeRepository
    {
        public WorkTypeRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new WorkTypeMapper(mapper))
        {
        }
        
        public override async Task<IEnumerable<DAL.App.DTO.WorkType>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));
            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DAL.App.DTO.WorkType?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .AsEnumerable()
                .Select(d => Mapper.Map(d))
                .FirstOrDefault(e => e!.Id.Equals(id));
            
            return resQuery!;
        }
    }
}