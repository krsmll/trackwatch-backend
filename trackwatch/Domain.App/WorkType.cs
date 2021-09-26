using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class WorkType : DomainEntityId
    {
        [MaxLength(32)] public string Name { get; set; } = default!;

        [MaxLength(256)] public string? Description { get; set; }
        
        public ICollection<Work>? Works { get; set; }
    }
}