using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class Genre : DomainEntityId
    {
        [MaxLength(32)] public string Name { get; set; } = default!;

        [MaxLength(1024)] public string? Description { get; set; }
        
        public ICollection<WorkGenre>? WorkGenres { get; set; }
    }
}