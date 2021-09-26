using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class Format : DomainEntityId
    {
        [MaxLength(64)] public string Name { get; set; } = default!;

        public ICollection<Work>? Works { get; set; }
    }
}