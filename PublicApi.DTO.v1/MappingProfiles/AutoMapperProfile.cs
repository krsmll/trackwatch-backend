using AutoMapper;
using PublicApi.DTO.v1.Identity;

namespace PublicApi.DTO.v1.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser,  BLL.App.DTO.Identity.AppUser>().ReverseMap();
            CreateMap<AppRole,  BLL.App.DTO.Identity.AppRole>().ReverseMap();
            CreateMap<Character,  BLL.App.DTO.Character>().ReverseMap();
            CreateMap<CharacterPicture,  BLL.App.DTO.CharacterPicture>().ReverseMap();
            CreateMap<CharacterInList,  BLL.App.DTO.CharacterInList>().ReverseMap();
            CreateMap<CoverPicture,  BLL.App.DTO.CoverPicture>().ReverseMap();
            CreateMap<FavCharacterList, BLL.App.DTO.FavCharacterList>().ReverseMap();
            CreateMap<Format,  BLL.App.DTO.Format>().ReverseMap();
            CreateMap<Genre,  BLL.App.DTO.Genre>().ReverseMap();
            CreateMap<Person,  BLL.App.DTO.Person>().ReverseMap();
            CreateMap<PersonPicture,  BLL.App.DTO.PersonPicture>().ReverseMap();
            CreateMap<RatingScale,  BLL.App.DTO.RatingScale>().ReverseMap();
            CreateMap<Role,  BLL.App.DTO.Role>().ReverseMap();
            CreateMap<Status,  BLL.App.DTO.Status>().ReverseMap();
            CreateMap<WatchList,  BLL.App.DTO.WatchList>().ReverseMap();
            CreateMap<Work,  BLL.App.DTO.Work>().ReverseMap();
            CreateMap<WorkAuthor,  BLL.App.DTO.WorkAuthor>().ReverseMap();
            CreateMap<WorkAuthorRole,  BLL.App.DTO.WorkAuthorRole>().ReverseMap();
            CreateMap<WorkCharacter,  BLL.App.DTO.WorkCharacter>().ReverseMap();
            CreateMap<WorkGenre,  BLL.App.DTO.WorkGenre>().ReverseMap();
            CreateMap<WorkInList,  BLL.App.DTO.WorkInList>().ReverseMap();
            CreateMap<WorkType,  BLL.App.DTO.WorkType>().ReverseMap();
            CreateMap<CharacterPerson,  BLL.App.DTO.CharacterPerson>().ReverseMap();
            CreateMap<WorkRelation,  BLL.App.DTO.WorkRelation>().ReverseMap();
        }
    }
}