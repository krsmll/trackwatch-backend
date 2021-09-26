using System;

namespace PublicApi.DTO.v1
{
    public class RatingScale
    {
        public Guid Id { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}