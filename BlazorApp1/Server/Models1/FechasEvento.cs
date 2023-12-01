using System;
using System.Collections.Generic;

namespace BlazorApp1.Server.Models1
{
    public partial class FechasEvento
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Descripcion { get; set; }
    }
}
