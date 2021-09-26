using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class PersonPicture : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.PersonPicture), Name = nameof(PersonId))]
        public Guid PersonId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.PersonPicture), Name = nameof(Person))]
        public Person? Person { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.PersonPicture), Name = nameof(URL))]
        public string URL { get; set; } = default!;
    }
}