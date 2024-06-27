﻿using System;
using System.Collections.Generic;

namespace GEEK.Models
{
    public partial class DetalleOrden
    {
        public string IdOrden { get; set; } = null!;
        public string IdProducto { get; set; } = null!;
        public string? IdUsuario { get; set; }
        public int? Cantidad { get; set; }
        public double? Precio { get; set; }

        public virtual Orden Orden { get; set; } = null!;
        public virtual Producto? Producto { get; set; } = null!;
        public virtual Usuario? Usuario { get; set; }
    }
}
