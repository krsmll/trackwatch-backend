using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class WorkAuthor : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkAuthor), Name = nameof(PersonId))]
        public Guid PersonId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkAuthor), Name = nameof(Person))]
        public Person? Person { get; set; }

        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkAuthor), Name = nameof(WorkId))]
        public Guid WorkId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkAuthor), Name = nameof(Work))]
        public Work? Work { get; set; }

        public ICollection<WorkAuthorRole>? WorkAuthorRoles { get; set; } = default!;
        public ICollection<CharacterPerson>? CharacterPersons { get; set; }
    }
}