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
    public class PersonPictureRepository : BaseRepository<DTO.PersonPicture, Domain.App.PersonPicture, AppDbContext>,
        IPersonPictureRepository
    {
        public PersonPictureRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new PersonPictureMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DTO.PersonPicture>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(c => c.Person)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<DTO.PersonPicture?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query
                .Include(c => c.Person)
                .AsEnumerable()
                .Select(x => Mapper.Map(x));
            
            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));

            return res!;
        }
    }
}