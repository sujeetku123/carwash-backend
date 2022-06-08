using System;
using System.Collections.Generic;

namespace Myproject.Models
{
    public partial class CarserviceFeedback
    {
        public int FeedbackId { get; set; }
        public string FirstName { get; set; } = null!;
        public decimal RatingValue { get; set; }
        public string FeedbackComments { get; set; } = null!;
    }
}
