using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.App.DTO
{
    public class CharacterPicture : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.CharacterPicture), Name = nameof(CharacterId))]
        public Guid CharacterId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.CharacterPicture), Name = nameof(Character))]
        public Character? Character { get; set; }

        [Display(ResourceType = typeof(Resources.BLL.App.DTO.CharacterPicture), Name = nameof(URL))]
        public string URL { get; set; } = default!;
    }
}