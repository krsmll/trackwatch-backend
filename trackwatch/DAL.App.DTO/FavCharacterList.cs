using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO.Identity;
using Domain.Base;

namespace DAL.App.DTO
{
    public class FavCharacterList : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.FavCharacterList), Name = nameof(AppUserId))]
        public Guid AppUserId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.FavCharacterList), Name = nameof(AppUser))]
        public AppUser? AppUser { get; set; }

        public ICollection<CharacterInList>? CharactersInList { get; set; }
    }
}