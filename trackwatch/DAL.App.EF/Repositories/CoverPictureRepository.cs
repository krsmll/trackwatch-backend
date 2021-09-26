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
    public class CoverPictureRepository : BaseRepository<DTO.CoverPicture, Domain.App.CoverPicture, AppDbContext>,
        ICoverPictureRepository
    {
        public CoverPictureRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new CoverPictureMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DTO.CoverPicture>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(c => c.Work)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.CoverPicture?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(c => c.Work)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.FirstOrDefaultAsync(e => e!.Id.Equals(id));

            return res!;
        }
    }
}