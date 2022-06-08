using System;
using System.Collections.Generic;

namespace Myproject.Models
{
    public partial class CarDetail
    {
        public string? Name { get; set; }
        public string EmailId { get; set; } = null!;
        public string? ContactNumber { get; set; }
        public string? CarModel { get; set; }
        public string? CarType { get; set; }
        public string? ServiceType { get; set; }
        public string? PreferredTime { get; set; }
        public string? Message { get; set; }
        public string? Address { get; set; }
        public string? Subscription { get; set; }
    }
}
