using System;

namespace PublicApi.DTO.v1
{
    public class CharacterPicture
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public string URL { get; set; } = default!;
    }
}