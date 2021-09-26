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
    public class FavCharacterListRepository : BaseRepository<DTO.FavCharacterList, Domain.App.FavCharacterList, AppDbContext>,
        IFavCharacterListRepository
    {
        public FavCharacterListRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new FavCharacterListMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DTO.FavCharacterList>> GetAllAsync(Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(a => a.CharactersInList)
                    .ThenInclude(a => a.Character)
                        .ThenInclude(a => a!.Pictures)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();
            
            return res!;
        }

        public override async Task<DTO.FavCharacterList?> FirstOrDefaultAsync(Guid id, Guid userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(a => a.CharactersInList)
                    .ThenInclude(a => a.Character)
                        .ThenInclude(a => a!.Pictures)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.FirstOrDefaultAsync(e => e!.Id.Equals(id));
            
            return res!;
        }
        
        public async Task<DTO.FavCharacterList?> FirstOrDefaultUserAsync(string username, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(default, noTracking);
            
            var resQuery = query
                .Include(a => a.AppUser)
                .Include(a => a.CharactersInList)
                    .ThenInclude(a => a.Character)
                        .ThenInclude(a => a!.Pictures)
                .AsEnumerable()
                .Select(x => Mapper.Map(x));
            
            var res = resQuery.FirstOrDefault(e => e!.AppUser!.UserName.Equals(username));
            
            return res!;
        }
    }
}