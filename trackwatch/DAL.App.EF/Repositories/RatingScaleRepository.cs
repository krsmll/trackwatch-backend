using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class RatingScaleRepository : BaseRepository<DTO.RatingScale, Domain.App.RatingScale, AppDbContext>,
        IRatingScaleRepository
    {
        public RatingScaleRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
            new RatingScaleMapper(mapper))
        {
        }
    }
}