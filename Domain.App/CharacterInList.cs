using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;
using Domain.Base;

namespace Domain.App
{
    public class CharacterInList : DomainEntityId
    {
        public Guid CharacterId { get; set; }
        public Character? Character { get; set; }

        public Guid FavCharacterListId { get; set; }
        public FavCharacterList? FavCharacterList { get; set; }
    }
}