using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models.Request
{
    public partial class AspnetroleRequest
    {


        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<AspNetRoleClaim> Aspnetroleclaims { get; set; }
        public virtual ICollection<AspNetUserRole> Aspnetuserroles { get; set; }
    }
}
