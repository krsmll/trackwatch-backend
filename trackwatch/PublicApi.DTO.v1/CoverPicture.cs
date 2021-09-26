using System;

namespace PublicApi.DTO.v1
{
    public class CoverPicture
    {
        public Guid Id { get; set; }
        public Guid WorkId { get; set; }
        public string URL { get; set; } = default!;
    }
}