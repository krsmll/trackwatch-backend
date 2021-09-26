using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Role : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Role), Name = nameof(Name))]
        [MaxLength(32)] public string Name { get; set; } = default!;
        
        public ICollection<WorkAuthorRole>? WorkAuthors { get; set; }
    }
}