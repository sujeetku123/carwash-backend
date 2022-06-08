using System;
using System.Collections.Generic;

namespace Myproject.Models
{
    public partial class Customer
    {
        public string EmailId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
