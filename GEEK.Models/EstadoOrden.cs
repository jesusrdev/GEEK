using System;
using System.Collections.Generic;

namespace GEEK.AccesoDatos.Models
{
    public partial class EstadoOrden
    {
        public EstadoOrden()
        {
            Ordens = new HashSet<Orden>();
        }

        public string IdEstadoOrden { get; set; } = null!;
        public string NombreEstadoOrden { get; set; } = null!;

        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
