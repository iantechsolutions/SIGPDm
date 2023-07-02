using System;
using System.Collections.Generic;

namespace BlazorApp1.Shared.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Names { get; set; } = null!;
        public string LastNames { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime Created { get; set; }
    }
}
