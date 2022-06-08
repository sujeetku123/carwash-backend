using System;
using System.Collections.Generic;

namespace Myproject.Models
{
    public partial class ServiceLogin
    {
        public int Id { get; set; }
        public string EmailId { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
