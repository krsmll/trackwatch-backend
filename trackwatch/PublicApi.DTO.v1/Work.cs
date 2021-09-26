using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.v1
{
    public class Work
    {
        public Guid Id { get; set; }
        public Guid FormatId { get; set; }
        public Format? Format { get; set; }
        public Guid WorkTypeId { get; set; }
        public WorkType? WorkType { get; set; }
        [MaxLength(128)] public string Title { get; set; } = default!;
        [MaxLength(2048)] public string Description { get; set; } = default!;
        public DateTime? ReleaseDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int EpisodeNumber { get; set; }

        public ICollection<WorkGenre>? WorkGenres { get; set; }
        public ICollection<WorkRelation>? RelatedWorks { get; set; }
        public ICollection<WorkRelation>? RelationOfWorks { get; set; }
        public ICollection<WorkCharacter>? WorkCharacters { get; set; }
        public ICollection<CoverPicture>? CoverPictures { get; set; }
        public ICollection<WorkAuthor>? WorkAuthors { get; set; }
    }
}