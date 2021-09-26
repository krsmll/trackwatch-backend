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
    public class WorkGenreRepository : BaseRepository<DTO.WorkGenre, Domain.App.WorkGenre, AppDbContext>,
        IWorkGenreRepository
    {
        public WorkGenreRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new WorkGenreMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DTO.WorkGenre>> GetAllAsync(Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(a => a.Work)
                .Include(a => a.Genre)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.WorkGenre?> FirstOrDefaultAsync(Guid id, Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(a => a.Work)
                .Include(a => a.Genre)
                .AsEnumerable()
                .Select(x => Mapper.Map(x));
            
            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));


            return res!;
        }
    }
}