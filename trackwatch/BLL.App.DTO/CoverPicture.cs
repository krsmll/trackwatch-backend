using System;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class CoverPicture : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.CoverPicture), Name = nameof(WorkId))]
        public Guid WorkId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.CoverPicture), Name = nameof(Work))]
        public Work? Work { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.CoverPicture), Name = nameof(URL))]
        public string URL { get; set; } = default!;
    }
}