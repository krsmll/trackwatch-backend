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
    public class CharacterRepository : BaseRepository<DTO.Character, Domain.App.Character, AppDbContext>,
        ICharacterRepository
    {
        public CharacterRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new CharacterMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DTO.Character>> GetAllAsync(Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Include(a => a.Pictures)
                .Include(a => a.CharacterInLists)
                    .ThenInclude(a => a.FavCharacterList)
                .Include(a => a.CharacterPersons)
                    .ThenInclude(a => a.WorkAuthor)
                        .ThenInclude(a => a!.WorkAuthorRoles)
                            .ThenInclude(a => a.Role)
                .Include(a => a.CharacterPersons)
                    .ThenInclude(a => a.WorkAuthor)
                        .ThenInclude(a => a!.Person)
                            .ThenInclude(a => a!.PersonPictures)
                .Include(a => a.WorkCharacters)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.CoverPictures)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.Character?> FirstOrDefaultAsync(Guid id, Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = (await query.Include(a => a.Pictures)
                .Include(a => a.CharacterInLists)
                    .ThenInclude(a => a.FavCharacterList)
                .Include(a => a.CharacterPersons)
                    .ThenInclude(a => a.WorkAuthor)
                        .ThenInclude(a => a!.WorkAuthorRoles)
                            .ThenInclude(a => a.Role)
                .Include(a => a.CharacterPersons)
                    .ThenInclude(a => a.WorkAuthor)
                        .ThenInclude(a => a!.Person)
                            .ThenInclude(a => a!.PersonPictures)
                .Include(a => a.WorkCharacters)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.CoverPictures)
                .ToListAsync()).Select(x => Mapper.Map(x));

            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));

            return res!;
        }
    }
}