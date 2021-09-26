using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class WatchList : DomainEntityId
    {
        public Guid RatingScaleId { get; set; }
        public RatingScale? RatingScale { get; set; }
        
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public ICollection<WorkInList>? WorkInLists { get; set; }
    }
}