using System;
using System.Collections.Generic;

namespace PublicApi.DTO.v1
{
    public class WatchList
    {
        public Guid Id { get; set; }
        public Guid RatingScaleId { get; set; }
        public RatingScale? RatingScale { get; set; }
        public Guid AppUserId { get; set; }
        
        public ICollection<WorkInList>? WorkInLists { get; set; }
    }
}