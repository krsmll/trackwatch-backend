using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class CharacterPerson : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CharacterPerson), Name = nameof(CharacterId))]
        public Guid CharacterId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CharacterPerson), Name = nameof(Character))]
        public Character? Character { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CharacterPerson), Name = nameof(WorkAuthorId))]
        public Guid WorkAuthorId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.CharacterPerson), Name = nameof(WorkAuthor))]
        public WorkAuthor? WorkAuthor { get; set; }
        
        
    }
}