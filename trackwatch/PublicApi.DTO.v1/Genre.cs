using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.v1
{
    public class Genre
    {
        public Guid Id { get; set; }
        [MaxLength(32)] public string Name { get; set; } = default!;

        [MaxLength(1024)] public string Description { get; set; } = default!;
        
        public ICollection<WorkGenre>? WorkGenres { get; set; }
    }
}