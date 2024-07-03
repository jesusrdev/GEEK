using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GEEK.Models
{
    public partial class Orden
    {
        public Orden()
        {
            DetalleOrden = new HashSet<DetalleOrden>();
        }

        public string IdOrden { get; set; } = null!;
        public string IdUsuario { get; set; }
        public string? EstadoOrden { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<DetalleOrden> DetalleOrden { get; set; }

        //[ForeignKey("idUsuario")]
        public virtual Usuario? Usuario { get; set; }
    }
}
