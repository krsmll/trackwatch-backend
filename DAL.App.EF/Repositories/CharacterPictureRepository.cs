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
    public class CharacterPictureRepository : BaseRepository<DTO.CharacterPicture, Domain.App.CharacterPicture, AppDbContext>,
        ICharacterPictureRepository
    {
        public CharacterPictureRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new CharacterPictureMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DTO.CharacterPicture>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(c => c.Character)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.CharacterPicture?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
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