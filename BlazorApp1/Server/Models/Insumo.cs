﻿using System;
using System.Collections.Generic;

namespace BlazorApp1.Server.Models
{
    public partial class Insumo
    {
        public Insumo()
        {
            Ordencompras = new HashSet<Ordencompra>();
        }

        public int Id { get; set; }
        public int? StockMin { get; set; }
        public int? StockMax { get; set; }
        public int? StockReal { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public string? Foto { get; set; }
        public string? Descripcion { get; set; }
        public string? Lotes { get; set; }
        public string? Recepcion { get; set; }
        public virtual ICollection<Ordencompra> Ordencompras { get; set; }

    }
}
