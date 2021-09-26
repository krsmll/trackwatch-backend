using System;
using System.Collections.Generic;

namespace PublicApi.DTO.v1
{
    public class WorkAuthor
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }
        public Guid WorkId { get; set; }
        public Work? Work { get; set; }

        public ICollection<WorkAuthorRole>? WorkAuthorRoles { get; set; }
    }
}