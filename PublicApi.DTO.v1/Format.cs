using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.v1
{
    public class Format
    {
        public Guid Id { get; set; }
        [MaxLength(64)] public string Name { get; set; } = default!;
        public ICollection<Work>? Works { get; set; }
    }
}