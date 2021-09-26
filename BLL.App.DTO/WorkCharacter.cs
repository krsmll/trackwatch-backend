using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.App.DTO
{
    public class WorkCharacter : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkCharacter), Name = nameof(WorkId))]
        public Guid WorkId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkCharacter), Name = nameof(Work))]
        public Work? Work { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkCharacter), Name = nameof(CharacterId))]
        public Guid CharacterId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.WorkCharacter), Name = nameof(Character))]
        public Character? Character { get; set; }
    }
}