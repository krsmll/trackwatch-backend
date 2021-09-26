using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.v1
{
    public class Person
    {
        public Guid Id { get; set; }
        [MaxLength(64)] public string FirstName { get; set; } = default!;

        [MaxLength(64)] public string LastName { get; set; } = default!;

        [MaxLength(64)] public string Nationality { get; set; } = default!;

        public DateTime Birthdate { get; set; }

        public ICollection<WorkAuthor>? WorkAuthors { get; set; }
        public ICollection<CharacterPerson>? CharacterPersons { get; set; }
        public ICollection<PersonPicture>? PersonPictures { get; set; }
    }
}