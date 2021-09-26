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
    public class WorkInListRepository : BaseRepository<DAL.App.DTO.WorkInList, Domain.App.WorkInList, AppDbContext>, IWorkInListRepository
    {
        public WorkInListRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new WorkInListMapper(mapper))
        {
        }
        
        public override async Task<IEnumerable<DAL.App.DTO.WorkInList>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            var resQuery = query.Include(a => a.Work)
                .Include(a => a.WatchList)
                .Select(x => Mapper.Map(x));
            
            var res = await resQuery.ToListAsync();
            
            return res!;
        }

        public override async Task<DAL.App.DTO.WorkInList?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            var resQuery = query.Include(a => a.Work)
                .Include(a => a.WatchList)
                .Include(a => a.Work)
                    .ThenInclude(a => a!.CoverPictures)
                .Include(a => a.Status)
                .AsEnumerable()
                .Select(x => Mapper.Map(x));


            return resQuery.FirstOrDefault(e => e!.Id.Equals(id));
        }
    }
}