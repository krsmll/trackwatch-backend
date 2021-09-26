using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WatchListRepository : BaseRepository<DTO.WatchList, Domain.App.WatchList, AppDbContext>,
        IWatchListRepository
    {
        public WatchListRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new WatchListMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DTO.WatchList>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(a => a.RatingScale)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.CoverPictures)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.WorkGenres)
                            .ThenInclude(a => a.Genre)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.Format)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.WorkType)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Status)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();
            
            return res!;
        }

        public override async Task<DTO.WatchList?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(a => a.RatingScale)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.CoverPictures)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.WorkGenres)
                            .ThenInclude(a => a.Genre)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.Format)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.WorkType)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Status)
                .AsEnumerable()
                .Select(x => Mapper.Map(x));
            
            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));

            return res!;
        }

        public async Task<WatchList?> FirstOrDefaultUserAsync(string username, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(default, noTracking);
            
            var resQuery = query
                .Include(a => a.AppUser)
                .Include(a => a.RatingScale)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.CoverPictures)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.WorkGenres)
                            .ThenInclude(a => a.Genre)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.Format)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.WorkType)
                .Include(a => a.WorkInLists)
                    .ThenInclude(a => a.Status)
                .AsEnumerable()
                .Select(x => Mapper.Map(x));
            
            var res = resQuery.FirstOrDefault(e => e!.AppUser!.UserName.Equals(username));
            
            return res!;
        }
    }
}