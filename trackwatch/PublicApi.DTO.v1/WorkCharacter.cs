using System;

namespace PublicApi.DTO.v1
{
    public class WorkCharacter
    {
        public Guid Id { get; set; }
        public Guid WorkId { get; set; }
        public Work? Work { get; set; }
        public Guid CharacterId { get; set; }
        public Character? Character { get; set; }
    }
}