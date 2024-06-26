using System;
using System.Collections.Generic;

namespace GEEK.Models
{
    public partial class EstadoProducto
    {
        public EstadoProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public string IdEstado { get; set; } = null!;
        public string NombreEstado { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
