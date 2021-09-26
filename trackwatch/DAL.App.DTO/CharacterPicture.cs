using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class CharacterPicture : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CharacterPicture), Name = nameof(CharacterId))]
        public Guid CharacterId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CharacterPicture), Name = nameof(Character))]
        public Character? Character { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CharacterPicture), Name = nameof(URL))]
        public string URL { get; set; } = default!;
    }
}