using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class CoverPicture : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CoverPicture), Name = nameof(WorkId))]
        public Guid WorkId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CoverPicture), Name = nameof(Work))]
        public Work? Work { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CoverPicture), Name = nameof(URL))]
        public string URL { get; set; } = default!;
    }
}