using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO.Identity;
using Domain.Base;

namespace DAL.App.DTO
{
    public class WatchList : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WatchList), Name = nameof(RatingScaleId))]
        public Guid RatingScaleId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WatchList), Name = nameof(RatingScale))]
        public RatingScale? RatingScale { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WatchList), Name = nameof(AppUserId))]
        public Guid AppUserId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WatchList), Name = nameof(AppUser))]
        public AppUser? AppUser { get; set; }

        public ICollection<WorkInList>? WorkInLists { get; set; }
    }
}