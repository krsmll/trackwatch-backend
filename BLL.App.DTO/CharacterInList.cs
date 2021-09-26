using System;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class CharacterInList : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.CharacterInList), Name = nameof(CharacterId))]
        public Guid CharacterId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.CharacterInList), Name = nameof(Character))]
        public Character? Character { get; set; }

        [Display(ResourceType = typeof(Resources.BLL.App.DTO.CharacterInList), Name = nameof(FavCharacterListId))]
        public Guid FavCharacterListId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.CharacterInList), Name = nameof(FavCharacterList))]
        public FavCharacterList? FavCharacterList { get; set; }
    }
}