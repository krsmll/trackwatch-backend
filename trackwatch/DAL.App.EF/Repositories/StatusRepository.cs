using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class StatusRepository : BaseRepository<DTO.Status, Domain.App.Status, AppDbContext>,
        IStatusRepository
    {
        public StatusRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new StatusMapper(mapper))
        {
            
        }
        
        public async Task<DTO.Status?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            await Task.CompletedTask;
            var query = CreateQuery(userId, noTracking);
            
            var resQuery = query
                .AsEnumerable()
                .Select(x => Mapper.Map(x));

            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));;
            
            return res!;
        }
    }
}