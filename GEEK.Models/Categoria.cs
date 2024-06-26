using System;
using System.Collections.Generic;

namespace GEEK.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public string IdCategoria { get; set; } = null!;
        public string DescripcionCategoria { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
