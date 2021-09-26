using System;

namespace PublicApi.DTO.v1
{
    public class WorkRelation
    {
        public Guid Id { get; set; }
        public Guid WorkId { get; set; }
        public Work? Work { get; set; }
        
        public Guid RelatedWorkId { get; set; }
        public Work? RelatedWork { get; set; }
    }
}