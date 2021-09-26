using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class Format : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Format), Name = nameof(Name))]
        [MaxLength(64)] public string Name { get; set; } = default!;

        public ICollection<Work>? Works { get; set; }
    }
}