using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class WorkAuthor : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkAuthor), Name = nameof(PersonId))]
        public Guid PersonId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkAuthor), Name = nameof(Person))]
        public Person? Person { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkAuthor), Name = nameof(WorkId))]
        public Guid WorkId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkAuthor), Name = nameof(Work))]
        public Work? Work { get; set; }

        public ICollection<WorkAuthorRole>? WorkAuthorRoles { get; set; }
        public ICollection<CharacterPerson>? CharacterPersons { get; set; }
    }
}