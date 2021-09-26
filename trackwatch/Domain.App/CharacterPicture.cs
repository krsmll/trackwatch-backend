using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class CharacterPicture : DomainEntityId
    {
        public Guid CharacterId { get; set; }
        public Character? Character { get; set; }

        public string URL { get; set; } = default!;
    }
}