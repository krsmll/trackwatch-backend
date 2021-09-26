using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class RatingScale : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.RatingScale), Name = nameof(MinValue))]
        public int MinValue { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.RatingScale), Name = nameof(MaxValue))]
        public int MaxValue { get; set; }
    }
}