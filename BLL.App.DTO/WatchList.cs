using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class WatchList : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WatchList), Name = nameof(RatingScaleId))]
        public Guid RatingScaleId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WatchList), Name = nameof(RatingScale))]
        public RatingScale? RatingScale { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WatchList), Name = nameof(AppUserId))]
        public Guid AppUserId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WatchList), Name = nameof(AppUser))]
        public AppUser? AppUser { get; set; }

        public ICollection<WorkInList>? WorkInLists { get; set; }
    }
}