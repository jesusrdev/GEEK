using System;
using System.Collections.Generic;

namespace GEEK.Models
{
    public partial class Imagen
    {
        public Imagen()
        {
            Productos = new HashSet<Producto>();
        }

        public string IdImagen { get; set; } = null!;
        public string RutaImagen { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
