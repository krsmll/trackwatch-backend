using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{ 
    public class WorkType : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkType), Name = nameof(Name))]
        [MaxLength(32)] public string Name { get; set; } = default!;

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkType), Name = nameof(Description))]
        [MaxLength(128)] public string? Description { get; set; }
        
        public ICollection<Work>? Works { get; set; }
    }
}