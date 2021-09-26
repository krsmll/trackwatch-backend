using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class CharacterInList : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CharacterInList), Name = nameof(CharacterId))]
        public Guid CharacterId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CharacterInList), Name = nameof(Character))]
        public Character? Character { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CharacterInList), Name = nameof(FavCharacterListId))]
        public Guid FavCharacterListId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CharacterInList), Name = nameof(FavCharacterList))]
        public FavCharacterList? FavCharacterList { get; set; }
    }
}