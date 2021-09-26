using System;
using System.Linq;
using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<Character> Characters { get; set; } = default!;
        public DbSet<CharacterInList> CharacterInLists { get; set; } = default!;
        public DbSet<CharacterPerson> CharacterPersons { get; set; } = default!;
        public DbSet<CharacterPicture> CharacterPictures { get; set; } = default!;
        public DbSet<CoverPicture> CoverPictures { get; set; } = default!;

        public DbSet<FavCharacterList> FavCharacterLists { get; set; } = default!;
        public DbSet<Format> Formats { get; set; } = default!;
        public DbSet<Genre> Genres { get; set; } = default!;
        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<PersonPicture> PersonPictures { get; set; } = default!;
        public DbSet<RatingScale> RatingScales { get; set; } = default!;
        public DbSet<Role> AuthorRoles { get; set; } = default!;
        public DbSet<Status> Statuses { get; set; } = default!;
        public DbSet<WorkType> Types { get; set; } = default!;
        public DbSet<WatchList> WatchLists { get; set; } = default!;
        public DbSet<Work> Works { get; set; } = default!;
        public DbSet<WorkRelation> WorkRelations { get; set; } = default!;
        public DbSet<WorkAuthor> WorkAuthors { get; set; } = default!;
        public DbSet<WorkAuthorRole> WorkAuthorRoles { get; set; } = default!;
        public DbSet<WorkCharacter> WorkCharacters { get; set; } = default!;
        public DbSet<WorkGenre> WorkGenres { get; set; } = default!;
        public DbSet<WorkInList> WorkInLists { get; set; } = default!;
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<WorkRelation>()
                .HasOne(w => w.Work)
                .WithMany(w => w!.RelatedWorks)
                .HasForeignKey(w => w.WorkId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<WorkRelation>()
                .HasOne(w => w.RelatedWork)
                .WithMany(w => w!.RelationOfWorks)
                .HasForeignKey(w => w.RelatedWorkId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}