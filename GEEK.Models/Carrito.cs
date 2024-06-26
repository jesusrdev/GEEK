using System;
using System.Collections.Generic;

namespace GEEK.AccesoDatos.Models
{
    public partial class Carrito
    {
        public Carrito()
        {
            Ordens = new HashSet<Orden>();
        }

        public string IdCarrito { get; set; } = null!;
        public string? IdProducto { get; set; }
        public string? IdUsuario { get; set; }
        public int? Cantidad { get; set; }

        public virtual Producto? IdProductoNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
