using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.v1.Identity
{
    public class AppUser
    {
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        public ICollection<WatchList>? WatchLists { get; set; }
        public ICollection<FavCharacterList>? FavCharacterLists { get; set; }
    }
}