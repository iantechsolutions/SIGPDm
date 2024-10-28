using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class Comments
    {
        public string Id { get; set; }

        public int? TicketId { get; set; }
        public string? TipoMessage { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
        public string? State { get; set; }

        public string? Urgency { get; set; }

        public DateTime? Created { get; set; }


    }
}
