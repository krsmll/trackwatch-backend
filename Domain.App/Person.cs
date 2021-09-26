using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class Person : DomainEntityId
    {
        [MaxLength(64)] public string FirstName { get; set; } = default!;

        [MaxLength(64)] public string LastName { get; set; } = default!;

        [MaxLength(64)] public string? Nationality { get; set; }

        public DateTime Birthdate { get; set; }
        
        public ICollection<WorkAuthor>? WorkAuthors { get; set; }
        public ICollection<CharacterPerson>? CharacterPersons { get; set; }
        public ICollection<PersonPicture>? PersonPictures { get; set; }
    }
}