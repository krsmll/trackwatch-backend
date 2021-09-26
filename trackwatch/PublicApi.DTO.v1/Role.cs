using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.v1
{
    public class Role
    {
        public Guid Id { get; set; }
        [MaxLength(32)] public string Name { get; set; } = default!;
        
        public ICollection<WorkAuthorRole>? WorkAuthors { get; set; }
    }
}