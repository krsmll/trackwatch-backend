using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO
{
    public class WorkGenre : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkGenre), Name = nameof(GenreId))]
        public Guid GenreId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkGenre), Name = nameof(Genre))]
        public Genre? Genre { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkGenre), Name = nameof(WorkId))]
        public Guid WorkId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.WorkGenre), Name = nameof(Work))]
        public Work? Work { get; set; }
    }
}