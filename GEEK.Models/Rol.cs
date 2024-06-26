using System;
using System.Collections.Generic;

namespace GEEK.AccesoDatos.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public string IdRol { get; set; } = null!;
        public string DescripcionRol { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
