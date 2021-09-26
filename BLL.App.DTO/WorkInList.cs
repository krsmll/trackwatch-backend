using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.App.DTO
{
    public class WorkInList : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkInList), Name = nameof(WatchListId))]
        public Guid WatchListId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkInList), Name = nameof(WatchList))]
        public WatchList? WatchList { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkInList), Name = nameof(WorkId))]
        public Guid WorkId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkInList), Name = nameof(Work))]
        public Work? Work { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkInList), Name = nameof(StatusId))]
        public Guid StatusId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkInList), Name = nameof(Status))]
        public Status? Status { get; set; }
        
        // started/finished watching dates
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkInList), Name = nameof(Started))]
        public DateTime Started { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkInList), Name = nameof(Finished))]
        public DateTime Finished { get; set; }

        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkInList), Name = nameof(Notes))]
        [MaxLength(248)] public string Notes { get; set; } = default!;

        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkInList), Name = nameof(Rating))]
        public float? Rating { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkInList), Name = nameof(EpisodesWatched))]
        public int EpisodesWatched { get; set; }
    }
}