using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Status : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Status), Name = nameof(Name))]
        [MaxLength(32)] public string Name { get; set; } = default!;
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Status), Name = nameof(Description))]
        [MaxLength(128)] public string? Description { get; set; }
    }
}