using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class WorkAuthor : DomainEntityId
    {
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }

        public Guid WorkId { get; set; }
        public Work? Work { get; set; }

        public ICollection<WorkAuthorRole>? WorkAuthorRoles { get; set; }
        public ICollection<CharacterPerson>? CharacterPersons { get; set; }
    }
}