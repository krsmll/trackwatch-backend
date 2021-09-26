using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class WorkInList : DomainEntityId
    {
        public Guid WatchListId { get; set; }
        public WatchList? WatchList { get; set; }
        
        public Guid WorkId { get; set; }
        public Work? Work { get; set; }
        
        public Guid StatusId { get; set; }
        public Status? Status { get; set; }
        
        // started/finished watching dates
        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }

        [MaxLength(248)] public string? Notes { get; set; }

        public int EpisodesWatched { get; set; }
        public float? Rating { get; set; }
    }
}