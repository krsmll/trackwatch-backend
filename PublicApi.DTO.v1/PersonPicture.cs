using System;

namespace PublicApi.DTO.v1
{
    public class PersonPicture
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string URL { get; set; } = default!;
    }
}