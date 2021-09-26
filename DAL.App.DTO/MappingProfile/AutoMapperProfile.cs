using AutoMapper;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, Domain.App.Identity.AppUser>().ReverseMap();
            CreateMap<AppRole, Domain.App.Identity.AppRole>().ReverseMap();
            CreateMap<Character, Domain.App.Character>().ReverseMap();
            CreateMap<CharacterInList, Domain.App.CharacterInList>().ReverseMap();
            CreateMap<CharacterPicture, Domain.App.CharacterPicture>().ReverseMap();
            CreateMap<CoverPicture, Domain.App.CoverPicture>().ReverseMap();
            CreateMap<FavCharacterList, Domain.App.FavCharacterList>().ReverseMap();
            CreateMap<Format, Domain.App.Format>().ReverseMap();
            CreateMap<Genre, Domain.App.Genre>().ReverseMap();
            CreateMap<Person, Domain.App.Person>().ReverseMap();
            CreateMap<PersonPicture, Domain.App.PersonPicture>().ReverseMap();
            CreateMap<RatingScale, Domain.App.RatingScale>().ReverseMap();
            CreateMap<Role, Domain.App.Role>().ReverseMap();
            CreateMap<Status, Domain.App.Status>().ReverseMap();
            CreateMap<WatchList, Domain.App.WatchList>().ReverseMap();
            CreateMap<Work, Domain.App.Work>().ReverseMap();
            CreateMap<WorkAuthor, Domain.App.WorkAuthor>().ReverseMap();
            CreateMap<WorkAuthorRole, Domain.App.WorkAuthorRole>().ReverseMap();
            CreateMap<WorkCharacter, Domain.App.WorkCharacter>().ReverseMap();
            CreateMap<WorkGenre, Domain.App.WorkGenre>().ReverseMap();
            CreateMap<WorkInList, Domain.App.WorkInList>().ReverseMap();
            CreateMap<WorkType, Domain.App.WorkType>().ReverseMap();
            CreateMap<CharacterPerson, Domain.App.CharacterPerson>().ReverseMap();
            CreateMap<WorkRelation, Domain.App.WorkRelation>().ReverseMap();
        }   
    }
}