using System;

namespace PublicApi.DTO.v1
{
    public class WorkAuthorRole
    {
        public Guid Id { get; set; }
        public Guid WorkAuthorId { get; set; }
        public WorkAuthor? WorkAuthor { get; set; }
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
    }
}