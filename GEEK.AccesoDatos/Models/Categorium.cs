using System;
using System.Collections.Generic;

namespace GEEK.AccesoDatos.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public string IdCategoria { get; set; } = null!;
        public string DescripcionCategoria { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
