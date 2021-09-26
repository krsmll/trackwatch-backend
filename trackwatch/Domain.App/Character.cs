using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class Character : DomainEntityId
    {
        [MaxLength(64)] public string FirstName { get; set; } = default!;

        [MaxLength(64)] public string? LastName { get; set; }

        [MaxLength(2048)] public string? Description { get; set; }

        public int? Age { get; set; }

        public DateTime? Birthdate { get; set; }

        public ICollection<WorkCharacter>? WorkCharacters { get; set; }
        
        public ICollection<CharacterPerson>? CharacterPersons { get; set; }
        public ICollection<CharacterPicture>? Pictures { get; set; }
        public ICollection<CharacterInList>? CharacterInLists { get; set; }
    }
}