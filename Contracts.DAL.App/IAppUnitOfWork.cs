using System;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        ICharacterInListRepository CharactersInLists { get; }
        ICharacterPictureRepository CharacterPictures { get; }
        
        ICharacterPersonRepository CharacterPersons { get; }
        ICharacterRepository Characters { get; }
        ICoverPictureRepository CoverPictures { get; }
        IFavCharacterListRepository FavCharacterLists { get; }
        IFormatRepository Formats { get; }
        IGenreRepository Genres { get; }
        IPersonPictureRepository PersonPictures { get; }
        IPersonRepository Persons { get; }
        IRatingScaleRepository RatingScales { get; }
        IRoleRepository Roles { get; }
        IStatusRepository Statuses { get; }
        IWatchListRepository WatchLists { get; }
        IWorkAuthorRepository WorkAuthors { get; }
        IWorkAuthorRoleRepository WorkAuthorRoles { get; }
        IWorkCharacterRepository WorkCharacters { get; }
        IWorkGenreRepository WorkGenres { get; }
        IWorkInListRepository WorkInLists { get; }
        IWorkRepository Works { get; }
        IWorkTypeRepository WorkTypes { get; }
        IWorkRelationRepository WorkRelations { get; }
    }
}