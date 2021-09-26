using System;
using Domain.Base;

namespace DAL.App.DTO
{
    public class WorkRelation : DomainEntityId
    {
        public Guid WorkId { get; set; }
        public Work? Work { get; set; }
        
        public Guid RelatedWorkId { get; set; }
        public Work? RelatedWork { get; set; }
    }
}