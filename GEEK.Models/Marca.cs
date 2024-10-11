using System;
using System.Collections.Generic;

namespace GEEK.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Productos = new HashSet<Producto>();
        }

        public string IdMarca { get; set; } = null!;
        public string NombreMarca { get; set; } = null!;
        public string RutaImagen { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
