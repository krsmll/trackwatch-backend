using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;
using Domain.Base;

namespace BLL.App.DTO
{
    public class FavCharacterList : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.FavCharacterList), Name = nameof(AppUserId))]
        public Guid AppUserId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.FavCharacterList), Name = nameof(AppUser))]
        public AppUser? AppUser { get; set; }

        public ICollection<CharacterInList>? CharactersInList { get; set; }
    }
}