using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class Work : DomainEntityId
    {
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Work), Name = nameof(FormatId))]
        public Guid FormatId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Work), Name = nameof(Format))]
        public Format? Format { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Work), Name = nameof(WorkTypeId))]
        public Guid WorkTypeId { get; set; }
        
        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Work), Name = nameof(WorkType))]
        public WorkType? WorkType { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Work), Name = nameof(Title))]
        [MaxLength(128)] public string Title { get; set; } = default!;

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Work), Name = nameof(Description))]
        [MaxLength(2048)] public string Description { get; set; } = default!;

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Work), Name = nameof(ReleaseDate))]
        public DateTime? ReleaseDate { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Work), Name = nameof(FinishDate))]
        public DateTime? FinishDate { get; set; }

        [Display(ResourceType = typeof(Resources.DAL.App.DTO.Work), Name = nameof(EpisodeNumber))]
        public int? EpisodeNumber { get; set; }

        public ICollection<WorkInList>? WorkInLists { get; set; }

        public ICollection<WorkGenre>? WorkGenres { get; set; }

        public ICollection<WorkRelation>? RelatedWorks { get; set; }
        
        public ICollection<WorkRelation>? RelationOfWorks { get; set; }
        
        public ICollection<WorkCharacter>? WorkCharacters { get; set; }

        public ICollection<CoverPicture>? CoverPictures { get; set; }

        public ICollection<WorkAuthor>? WorkAuthors { get; set; }
    }
}