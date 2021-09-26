using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class RatingScale : DomainEntityId
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}