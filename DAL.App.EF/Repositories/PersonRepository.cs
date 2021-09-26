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
    public class PersonRepository : BaseRepository<DTO.Person, Domain.App.Person, AppDbContext>,
        IPersonRepository
    {
        public PersonRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new PersonMapper(mapper))
        {
        }   
        
        public override async Task<IEnumerable<DTO.Person>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Include(c => c.PersonPictures)
                .Include(a => a.WorkAuthors)
                    .ThenInclude(a => a.Work)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.Person?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Include(c => c.PersonPictures)
                .Include(a => a.WorkAuthors)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.CoverPictures)
                .Include(a => a.CharacterPersons)
                    .ThenInclude(a => a.Character)
                        .ThenInclude(a => a!.Pictures)
                .AsEnumerable()
                .Select(x => Mapper.Map(x));
            
            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));

            return res!;
        }
    }
}