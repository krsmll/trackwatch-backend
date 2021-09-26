using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.App
{
    public class WorkGenre : DomainEntityId
    {
        public Guid GenreId { get; set; }
        public Genre? Genre { get; set; }
        
        public Guid WorkId { get; set; }
        public Work? Work { get; set; }
    }
}