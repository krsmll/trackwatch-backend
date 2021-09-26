using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Format : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Format), Name = nameof(Name))]
        [MaxLength(64)] 
        public string Name { get; set; } = default!;

        public ICollection<Work>? Works { get; set; }
    }
}