using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class TimesEtapa
    {
        public string Etapa { get; set; }
        public int? TimeTotalEtapa { get; set; }
        public DateTime? TimeEtapa { get; set; }
        
        public TimesEtapa(string etapa)
        {
            this.Etapa = etapa;
        }
    }
}
