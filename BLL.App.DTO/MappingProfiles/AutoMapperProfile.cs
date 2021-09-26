using AutoMapper;
using BLL.App.DTO.Identity;

namespace BLL.App.DTO.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, DAL.App.DTO.Identity.AppUser>().ReverseMap();
            CreateMap<AppRole, DAL.App.DTO.Identity.AppRole>().ReverseMap();
            CreateMap<Character, DAL.App.DTO.Character>().ReverseMap();
            CreateMap<CharacterInList, DAL.App.DTO.CharacterInList>().ReverseMap();
            CreateMap<CharacterPicture, DAL.App.DTO.CharacterPicture>().ReverseMap();
            CreateMap<CoverPicture, DAL.App.DTO.CoverPicture>().ReverseMap();
            CreateMap<FavCharacterList, DAL.App.DTO.FavCharacterList>().ReverseMap();
            CreateMap<Format, DAL.App.DTO.Format>().ReverseMap();
            CreateMap<Genre, DAL.App.DTO.Genre>().ReverseMap();
            CreateMap<Person, DAL.App.DTO.Person>().ReverseMap();
            CreateMap<PersonPicture, DAL.App.DTO.PersonPicture>().ReverseMap();
            CreateMap<RatingScale, DAL.App.DTO.RatingScale>().ReverseMap();
            CreateMap<Role, DAL.App.DTO.Role>().ReverseMap();
            CreateMap<Status, DAL.App.DTO.Status>().ReverseMap();
            CreateMap<WatchList, DAL.App.DTO.WatchList>().ReverseMap();
            CreateMap<Work, DAL.App.DTO.Work>().ReverseMap();
            CreateMap<WorkAuthor, DAL.App.DTO.WorkAuthor>().ReverseMap();
            CreateMap<WorkAuthorRole, DAL.App.DTO.WorkAuthorRole>().ReverseMap();
            CreateMap<WorkCharacter, DAL.App.DTO.WorkCharacter>().ReverseMap();
            CreateMap<WorkGenre, DAL.App.DTO.WorkGenre>().ReverseMap();
            CreateMap<WorkInList, DAL.App.DTO.WorkInList>().ReverseMap();
            CreateMap<WorkType, DAL.App.DTO.WorkType>().ReverseMap();
            CreateMap<CharacterPerson, DAL.App.DTO.CharacterPerson>().ReverseMap();
            CreateMap<WorkRelation, DAL.App.DTO.WorkRelation>().ReverseMap();
        }   
    }
}