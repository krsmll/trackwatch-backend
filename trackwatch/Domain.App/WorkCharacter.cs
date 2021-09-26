using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class WorkCharacter : DomainEntityId
    {
        public Guid WorkId { get; set; }
        public Work? Work { get; set; }
        
        public Guid CharacterId { get; set; }
        public Character? Character { get; set; }
    }
}