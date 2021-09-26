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
    public class CharacterPersonRepository :
        BaseRepository<DTO.CharacterPerson, Domain.App.CharacterPerson, AppDbContext>,
        ICharacterPersonRepository
    {
        public CharacterPersonRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new CharacterPersonMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DTO.CharacterPerson>> GetAllAsync(Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(c => c.Character)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.CharacterPerson?> FirstOrDefaultAsync(Guid id, Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(c => c.Character).AsEnumerable()
                .Select(x => Mapper.Map(x));

            var res = resQuery.FirstOrDefault(x => id.Equals(x!.Id));

            return res!;
        }
    }
}