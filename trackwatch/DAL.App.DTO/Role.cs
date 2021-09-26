using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class Role : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Role), Name = nameof(Name))]
        [MaxLength(32)] public string Name { get; set; } = default!;
        
        public ICollection<WorkAuthorRole>? WorkAuthors { get; set; }
    }
}