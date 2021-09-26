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
    public class WorkAuthorRepository : BaseRepository<DTO.WorkAuthor, Domain.App.WorkAuthor, AppDbContext>,
        IWorkAuthorRepository
    {
        public WorkAuthorRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new WorkAuthorMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DTO.WorkAuthor>> GetAllAsync(Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(a => a.Person)
                .Include(a => a.Work)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.WorkAuthor?> FirstOrDefaultAsync(Guid id, Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                    .Include(a => a.Person)
                    .Include(a => a.Work)
                    .AsEnumerable()
                    .Select(x => Mapper.Map(x));
            
            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));

            return res!;
        }
    }
}