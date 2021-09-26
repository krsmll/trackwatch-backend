using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Person : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Person), Name = nameof(FirstName))]
        [MaxLength(64)] public string FirstName { get; set; } = default!;

        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Person), Name = nameof(LastName))]
        [MaxLength(64)] public string LastName { get; set; } = default!;

        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Person), Name = nameof(Nationality))]
        [MaxLength(64)] public string Nationality { get; set; } = default!;

        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Person), Name = nameof(Birthdate))]
        public DateTime Birthdate { get; set; }
        
        public ICollection<WorkAuthor>? WorkAuthors { get; set; }
        
        public ICollection<CharacterPerson>? CharacterPersons { get; set; }
        
        public ICollection<PersonPicture>? PersonPictures { get; set; }
    }
}