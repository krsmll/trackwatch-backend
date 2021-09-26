using AutoMapper;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        private IMapper Mapper;
        public AppUnitOfWork(AppDbContext uowDbContext, IMapper mapper) : base(uowDbContext)
        {
            Mapper = mapper;
        }

        public ICharacterInListRepository CharactersInLists =>
            GetRepository(() => new CharacterInListRepository(UowDbContext, Mapper));

        public ICharacterPictureRepository CharacterPictures =>
            GetRepository(() => new CharacterPictureRepository(UowDbContext, Mapper));

        public ICharacterPersonRepository CharacterPersons =>
            GetRepository(() => new CharacterPersonRepository(UowDbContext, Mapper));

        public ICharacterRepository Characters =>
            GetRepository(() => new CharacterRepository(UowDbContext, Mapper));

        public ICoverPictureRepository CoverPictures =>
            GetRepository(() => new CoverPictureRepository(UowDbContext, Mapper));

        public IFavCharacterListRepository FavCharacterLists =>
            GetRepository(() => new FavCharacterListRepository(UowDbContext, Mapper));

        public IFormatRepository Formats =>
            GetRepository(() => new FormatRepository(UowDbContext, Mapper));

        public IGenreRepository Genres =>
            GetRepository(() => new GenreRepository(UowDbContext, Mapper));

        public IPersonPictureRepository PersonPictures =>
            GetRepository(() => new PersonPictureRepository(UowDbContext, Mapper));

        public IPersonRepository Persons =>
            GetRepository(() => new PersonRepository(UowDbContext, Mapper));

        public IRatingScaleRepository RatingScales =>
            GetRepository(() => new RatingScaleRepository(UowDbContext, Mapper));

        public IRoleRepository Roles =>
            GetRepository(() => new RoleRepository(UowDbContext, Mapper));

        public IStatusRepository Statuses =>
            GetRepository(() => new StatusRepository(UowDbContext, Mapper));

        public IWatchListRepository WatchLists =>
            GetRepository(() => new WatchListRepository(UowDbContext, Mapper));

        public IWorkAuthorRepository WorkAuthors =>
            GetRepository(() => new WorkAuthorRepository(UowDbContext, Mapper));

        public IWorkAuthorRoleRepository WorkAuthorRoles =>
            GetRepository(() => new WorkAuthorRoleRepository(UowDbContext, Mapper));

        public IWorkCharacterRepository WorkCharacters =>
            GetRepository(() => new WorkCharacterRepository(UowDbContext, Mapper));

        public IWorkGenreRepository WorkGenres =>
            GetRepository(() => new WorkGenreRepository(UowDbContext, Mapper));

        public IWorkInListRepository WorkInLists =>
            GetRepository(() => new WorkInListRepository(UowDbContext, Mapper));
        
        public IWorkRepository Works =>
            GetRepository(() => new WorkRepository(UowDbContext, Mapper));
        
        public IWorkTypeRepository WorkTypes =>
            GetRepository(() => new WorkTypeRepository(UowDbContext, Mapper));
        
        public IWorkRelationRepository WorkRelations =>
            GetRepository(() => new WorkRelationRepository(UowDbContext, Mapper));
    }
}