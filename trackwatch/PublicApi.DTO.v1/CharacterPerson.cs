using System;

namespace PublicApi.DTO.v1
{
    public class CharacterPerson
    {
        public Guid Id { get; set; }
        
        public Guid CharacterId { get; set; }
        public Character? Character { get; set; }
        
        public Guid WorkAuthorId { get; set; }
        public WorkAuthor? WorkAuthor { get; set; }
    }
}