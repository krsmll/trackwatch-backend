using AutoMapper;
using BLL.App.Mappers;
using BLL.App.Services;
using BLL.Base;
using BLL.Base.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base.Repositories;


namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        protected IMapper Mapper;
        
        public AppBLL(IAppUnitOfWork uow, IMapper mapper) : base(uow)
        {
            Mapper = mapper;
        }

        public ICharacterInListService CharacterInLists =>
            GetService<ICharacterInListService>(() => new CharacterInListService(Uow, Uow.CharactersInLists, Mapper));

        public ICharacterPictureService CharacterPictures =>
            GetService<ICharacterPictureService>(() => new CharacterPictureService(Uow, Uow.CharacterPictures, Mapper));

        public ICharacterPersonService CharacterPersons =>
            GetService<ICharacterPersonService>(() => new CharacterPersonService(Uow, Uow.CharacterPersons, Mapper));

        public ICharacterService Characters =>
            GetService<ICharacterService>(() => new CharacterService(Uow, Uow.Characters, Mapper));
        
        public ICoverPictureService CoverPictures =>
            GetService<ICoverPictureService>(() => new CoverPictureService(Uow, Uow.CoverPictures, Mapper));

        public IFavCharacterListService FavCharacterLists =>
            GetService<IFavCharacterListService>(() => new FavCharacterListService(Uow, Uow.FavCharacterLists, Mapper));
        
        public IFormatService Formats =>
            GetService<IFormatService>(() => new FormatService(Uow, Uow.Formats, Mapper));
        
        public IGenreService Genres =>
            GetService<IGenreService>(() => new GenreService(Uow, Uow.Genres, Mapper));
        
        public IPersonPictureService PersonPictures =>
            GetService<IPersonPictureService>(() => new PersonPictureService(Uow, Uow.PersonPictures, Mapper));
        
        public IPersonService Persons =>
            GetService<IPersonService>(() => new PersonService(Uow, Uow.Persons, Mapper));
        
        public IRatingScaleService RatingScales =>
            GetService<IRatingScaleService>(() => new RatingScaleService(Uow, Uow.RatingScales, Mapper));
        
        public IRoleService Roles =>
            GetService<IRoleService>(() => new RoleService(Uow, Uow.Roles, Mapper));
        
        public IStatusService Statuses =>
            GetService<IStatusService>(() => new StatusService(Uow, Uow.Statuses, Mapper));
        
        public IWatchListService WatchLists =>
            GetService<IWatchListService>(() => new WatchListService(Uow, Uow.WatchLists, Mapper));
        
        public IWorkAuthorRoleService WorkAuthorRoles =>
            GetService<IWorkAuthorRoleService>(() => new WorkAuthorRoleService(Uow, Uow.WorkAuthorRoles, Mapper));

        public IWorkAuthorService WorkAuthors =>
            GetService<IWorkAuthorService>(() => new WorkAuthorService(Uow, Uow.WorkAuthors, Mapper));

        public IWorkCharacterService WorkCharacters =>
            GetService<IWorkCharacterService>(() => new WorkCharacterService(Uow, Uow.WorkCharacters, Mapper));

        public IWorkGenreService WorkGenres =>
            GetService<IWorkGenreService>(() => new WorkGenreService(Uow, Uow.WorkGenres, Mapper));

        public IWorkInListService WorkInLists =>
            GetService<IWorkInListService>(() => new WorkInListService(Uow, Uow.WorkInLists, Mapper));

        public IWorkService Works =>
            GetService<IWorkService>(() => new WorkService(Uow, Uow.Works, Mapper));

        public IWorkTypeService WorkTypes =>
            GetService<IWorkTypeService>(() => new WorkTypeService(Uow, Uow.WorkTypes, Mapper));

        public IWorkRelationService WorkRelations =>
            GetService<IWorkRelationService>(() => new WorkRelationService(Uow, Uow.WorkRelations, Mapper));
    }
}