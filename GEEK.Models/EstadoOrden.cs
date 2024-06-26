using System;
using System.Collections.Generic;

namespace GEEK.Models
{
    public partial class EstadoOrden
    {
        public EstadoOrden()
        {
            Ordenes = new HashSet<Orden>();
        }

        public string IdEstadoOrden { get; set; } = null!;
        public string NombreEstadoOrden { get; set; } = null!;

        public virtual ICollection<Orden> Ordenes { get; set; }
    }
}
