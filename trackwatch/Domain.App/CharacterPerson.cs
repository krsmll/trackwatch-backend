using System;
using Domain.Base;

namespace Domain.App
{
    public class CharacterPerson : DomainEntityId
    {
        public Guid CharacterId { get; set; }
        public Character? Character { get; set; }

        public Guid WorkAuthorId { get; set; }
        public WorkAuthor? WorkAuthor { get; set; }
    }
}