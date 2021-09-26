using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Genre : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Genre), Name = nameof(Name))]
        [MaxLength(32)] 
        public string Name { get; set; } = default!;

        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Genre), Name = nameof(Description))]
        [MaxLength(1024)] public string Description { get; set; } = default!;
        
        public ICollection<WorkGenre>? WorkGenres { get; set; }
    }
}