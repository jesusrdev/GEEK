using System;
using System.Collections.Generic;

namespace GEEK.Models
{
    public partial class Carrito
    {
        public Carrito()
        {
            Ordenes = new HashSet<Orden>();
        }

        public string IdCarrito { get; set; } = null!;
        public string? IdProducto { get; set; }
        public string? IdUsuario { get; set; }
        public int? Cantidad { get; set; }

        public virtual Producto? Producto { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<Orden> Ordenes { get; set; }
    }
}
