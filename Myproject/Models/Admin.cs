using System;
using System.Collections.Generic;

namespace Myproject.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string EmailId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
