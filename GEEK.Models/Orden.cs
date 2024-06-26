using System;
using System.Collections.Generic;

namespace GEEK.Models
{
    public partial class Orden
    {
        public string IdOrden { get; set; } = null!;
        public string? IdCarrito { get; set; }
        public string? IdUsuario { get; set; }
        public string? IdEstadoOrden { get; set; }
        public int? Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Carrito? Carrito { get; set; }
        public virtual EstadoOrden? EstadoOrden { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
