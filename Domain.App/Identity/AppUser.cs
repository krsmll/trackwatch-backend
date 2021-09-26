using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        [StringLength(128, MinimumLength = 1)]
        public string? Firstname { get; set; }
        [StringLength(128, MinimumLength = 1)]
        public string? Lastname { get; set; }

        public ICollection<WatchList>? WatchLists { get; set; }
        public ICollection<FavCharacterList>? FavCharacterLists { get; set; }

    }
}