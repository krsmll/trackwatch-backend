using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class WorkAuthorRole : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkAuthorRole), Name = nameof(WorkAuthorId))]
        public Guid WorkAuthorId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkAuthorRole), Name = nameof(WorkAuthor))]
        public WorkAuthor? WorkAuthor { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkAuthorRole), Name = nameof(RoleId))]
        public Guid RoleId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkAuthorRole), Name = nameof(Role))]
        public Role? Role { get; set; }
    }
}