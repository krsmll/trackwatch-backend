using System;

namespace PublicApi.DTO.v1
{
    public class CharacterInList
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public Character? Character { get; set; }
        public Guid FavCharacterListId { get; set; }
        public FavCharacterList? FavCharacterList { get; set; }
    }
}