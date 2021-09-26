using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkRepository : BaseRepository<Work, Domain.App.Work, AppDbContext>, IWorkRepository
    {
        public WorkRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new WorkMapper(mapper))
        {
        }
        
        public override async Task<IEnumerable<Work>> GetAllAsync(Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            var resQuery = query.Include(a => a.Format)
                .Include(a => a.CoverPictures)
                .Include(a => a.RelatedWorks)
                    .ThenInclude(a => a.RelatedWork)
                        .ThenInclude(a => a!.CoverPictures)
                .Include(a => a.RelationOfWorks)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.CoverPictures)
                .Include(a => a.WorkAuthors)
                    .ThenInclude(a => a.Person)
                .Include(a => a.WorkAuthors)
                    .ThenInclude(a => a.WorkAuthorRoles)
                        .ThenInclude(a => a.Role)
                .Include(a => a.WorkGenres)
                    .ThenInclude(a => a.Genre)
                .Include(a => a.WorkCharacters)
                    .ThenInclude(a => a.Character)
                        .ThenInclude(a => a!.Pictures)
                .Include(a => a.WorkType)
                .Select(x => Mapper.Map(x));

            var res = await resQuery.ToListAsync();

            return res!;
        }

        public override async Task<Work?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            var resQuery = query.Include(a => a.Format)
                .Include(a => a.CoverPictures)
                .Include(a => a.RelatedWorks)
                    .ThenInclude(a => a.RelatedWork)
                        .ThenInclude(a => a!.CoverPictures)
                .Include(a => a.RelationOfWorks)
                    .ThenInclude(a => a.Work)
                        .ThenInclude(a => a!.CoverPictures)
                .Include(a => a.WorkAuthors)
                    .ThenInclude(a => a.Person)
                .Include(a => a.WorkAuthors)
                    .ThenInclude(a => a.WorkAuthorRoles)
                        .ThenInclude(a => a.Role)
                .Include(a => a.WorkGenres)
                    .ThenInclude(a => a.Genre)
                .Include(a => a.WorkType)
                .Include(a => a.WorkCharacters)
                    .ThenInclude(a => a.Character)
                        .ThenInclude(a => a!.Pictures)
                .AsEnumerable()
                .Select(d => Mapper.Map(d));

            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));
            return res;
        }

        public async Task<Work?> FirstOrDefaultNoIncludesAsync(Guid id, Guid userId = default, bool noTracking = true)
        {
            await Task.CompletedTask;
            var query = CreateQuery(userId, noTracking);

            var resQuery = query
                .AsEnumerable()
                .Select(d => Mapper.Map(d));

            var res = resQuery.FirstOrDefault(e => e!.Id.Equals(id));
            return res;
        }
    }
}