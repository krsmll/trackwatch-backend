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
    public class GenreRepository : BaseRepository<DTO.Genre, Domain.App.Genre, AppDbContext>,
        IGenreRepository
    {
        public GenreRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new GenreMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DTO.Genre>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Include(c => c.WorkGenres)
                .ThenInclude(w => w.Work)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.Genre?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Include(c => c.WorkGenres)
                .ThenInclude(w => w.Work)
                .AsEnumerable()
                .Select(x => Mapper.Map(x));
            
            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));

            return res!;
        }
    }
}