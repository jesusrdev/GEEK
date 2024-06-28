using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GEEK.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        [Display(Name = "Id Categoria")]
        public string IdCategoria { get; set; } = null!;
        [Display(Name = "Descripcion Categoria")]
        [Required(ErrorMessage = "Descripcion de Categoria" )]
        public string DescripcionCategoria { get; set; } = null!;

        public virtual ICollection<Producto>? Productos { get; set; }
    }
}
