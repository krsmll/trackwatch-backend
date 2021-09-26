using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.App.DTO
{
    public class WorkAuthorRole : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkAuthorRole), Name = nameof(WorkAuthorId))]
        public Guid WorkAuthorId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkAuthorRole), Name = nameof(WorkAuthor))]
        public WorkAuthor? WorkAuthor { get; set; }

        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkAuthorRole), Name = nameof(RoleId))]
        public Guid RoleId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkAuthorRole), Name = nameof(Role))]
        public Role? Role { get; set; }
    }
}