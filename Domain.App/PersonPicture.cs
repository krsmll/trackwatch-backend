using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class PersonPicture : DomainEntityId
    {
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }

        public string URL { get; set; } = default!;
    }
}