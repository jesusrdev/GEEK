using System;
using System.Collections.Generic;

namespace GEEK.AccesoDatos.Models
{
    public partial class Imagen
    {
        public Imagen()
        {
            IdProductos = new HashSet<Producto>();
        }

        public string IdImagen { get; set; } = null!;
        public string RutaImagen { get; set; } = null!;

        public virtual ICollection<Producto> IdProductos { get; set; }
    }
}
