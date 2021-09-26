using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class WorkAuthorRole : DomainEntityId
    {
        public Guid WorkAuthorId { get; set; }
        public WorkAuthor? WorkAuthor { get; set; }

        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
    }
}