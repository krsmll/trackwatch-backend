using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class Role : DomainEntityId
    {
        [MaxLength(32)] public string Name { get; set; } = default!;
        
        public ICollection<WorkAuthorRole>? WorkAuthors { get; set; }
    }
}