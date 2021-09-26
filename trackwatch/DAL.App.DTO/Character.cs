using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class Character : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Character), Name = nameof(FirstName))]
        [MaxLength(64)] public string FirstName { get; set; } = default!;
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Character), Name = nameof(LastName))]
        [MaxLength(64)] public string? LastName { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Character), Name = nameof(Description))]
        [MaxLength(2048)] public string? Description { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Character), Name = nameof(Age))]
        public int? Age { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Character), Name = nameof(Birthdate))]
        public DateTime? Birthdate { get; set; }

        public ICollection<WorkCharacter>? WorkCharacters { get; set; }
        
        public ICollection<CharacterPerson>? CharacterPersons { get; set; }

        public ICollection<CharacterPicture>? Pictures { get; set; }

        public ICollection<CharacterInList>? CharacterInLists { get; set; }
    }
}