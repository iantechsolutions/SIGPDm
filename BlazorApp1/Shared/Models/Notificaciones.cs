using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class Notificaciones
    {
        public int? Id { get; set; }
        public string? RolesAfectados { get; set; }
        public string? UsuariosQueAfecta { get; set; }
        public string? UsuariosVisto { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public string? UrlRedireccion { get; set; }
        public DateTime? FechaCreacion { get; set; }

    }
}
