using System;
using System.Collections.Generic;

namespace PublicApi.DTO.v1
{
    public class FavCharacterList
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public ICollection<CharacterInList>? CharactersInList { get; set; }
    }
}