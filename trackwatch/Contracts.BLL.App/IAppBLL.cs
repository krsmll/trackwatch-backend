using System;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base;
using Contracts.BLL.Base.Services;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;
namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        ICharacterInListService CharacterInLists { get; }
        ICharacterPictureService CharacterPictures { get; }
        ICharacterPersonService CharacterPersons { get; }
        ICharacterService Characters { get; }
        ICoverPictureService CoverPictures { get; }
        IFavCharacterListService FavCharacterLists { get; }
        IFormatService Formats { get; }
        IGenreService Genres { get; }
        IPersonPictureService PersonPictures { get; }
        IPersonService Persons { get; }
        IRatingScaleService RatingScales { get; }
        IRoleService Roles { get; }
        IStatusService Statuses { get; }
        IWatchListService WatchLists { get; }
        IWorkAuthorRoleService WorkAuthorRoles { get; }
        IWorkAuthorService WorkAuthors { get; }
        IWorkCharacterService WorkCharacters { get; }
        IWorkGenreService WorkGenres { get; }
        IWorkInListService WorkInLists { get; }
        IWorkService Works { get; }
        IWorkTypeService WorkTypes { get; }
        IWorkRelationService WorkRelations { get; }
    }
}