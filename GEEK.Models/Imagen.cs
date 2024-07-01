using System;
using System.Collections.Generic;

namespace GEEK.Models
{
    public partial class Imagen
    {

        public string IdImagen { get; set; } = null!;
        public string RutaImagen { get; set; } = null!;

        public string IdProducto { get; set; } = null!;
        public Producto Producto { get; set; }
    }
}
