using System;

namespace PublicApi.DTO.v1
{
    public class WorkGenre
    {
        public Guid Id { get; set; }
        
        public Guid GenreId { get; set; }
        public Genre? Genre { get; set; }
        
        public Guid WorkId { get; set; }
        public Work? Work { get; set; }
    }
}