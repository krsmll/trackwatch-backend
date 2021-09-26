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
    public class CharacterInListRepository : BaseRepository<DTO.CharacterInList, Domain.App.CharacterInList, AppDbContext>,
        ICharacterInListRepository
    {
        private readonly DbContext _context;

        public CharacterInListRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new CharacterInListMapper(mapper))
        {
            _context = dbContext;
        }

        public override async Task<IEnumerable<DTO.CharacterInList>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(c => c.Character)
                .Include(c => c.FavCharacterList)
                .Select(x => Mapper.Map(x));
            
            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.CharacterInList?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
       
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(c => c.Character)
                .Include(c => c.FavCharacterList)
                .AsEnumerable()
                .Select(x => Mapper.Map(x));
            
            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));

            return res!;
        }
    }
}