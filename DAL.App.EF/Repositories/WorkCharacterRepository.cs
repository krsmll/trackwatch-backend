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
    public class WorkCharacterRepository : BaseRepository<DTO.WorkCharacter, Domain.App.WorkCharacter, AppDbContext>,
        IWorkCharacterRepository
    {
        public WorkCharacterRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new WorkCharacterMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DTO.WorkCharacter>> GetAllAsync(Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(a => a.Work)
                .Include(a => a.Character)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.WorkCharacter?> FirstOrDefaultAsync(Guid id, Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(a => a.Work)
                .Include(a => a.Character)
                .AsEnumerable()
                .Select(x => Mapper.Map(x));

            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));


            return res!;
        }
    }
}