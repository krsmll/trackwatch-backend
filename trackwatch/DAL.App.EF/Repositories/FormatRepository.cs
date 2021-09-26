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
    public class FormatRepository : BaseRepository<DTO.Format, Domain.App.Format, AppDbContext>,
        IFormatRepository
    {
        public FormatRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new FormatMapper(mapper))
        {
        }
        
        public override async Task<IEnumerable<DTO.Format>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(c => c.Works)
                .Select(x => Mapper.Map(x));

            var res = await  resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.Format?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(c => c.Works)
                .AsEnumerable()
                .Select(x => Mapper.Map(x));

            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));

            return res!;
        }
    }
}