using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class CoverPicture : DomainEntityId
    {
        public Guid WorkId { get; set; }
        public Work? Work { get; set; }

        public string URL { get; set; } = default!;
    }
}