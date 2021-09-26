using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkRelationRepository : BaseRepository<DTO.WorkRelation, Domain.App.WorkRelation, AppDbContext>, IWorkRelationRepository
    {
        public WorkRelationRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new WorkRelationMapper(mapper))
        {
        }
        
        public override async Task<IEnumerable<DTO.WorkRelation>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            var resQuery = query
                .Include(w => w.Work)
                    .ThenInclude(w => w!.CoverPictures)
                .Include(w => w.RelatedWork)
                    .ThenInclude(w => w!.CoverPictures)
                .IgnoreAutoIncludes()
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.WorkRelation?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            var resQuery = query
                .AsEnumerable()
                .Select(d => Mapper.Map(d)).FirstOrDefault(e => e!.Id.Equals(id));
            
            return resQuery;
        }
        
    }
}