using System;
using System.Collections.Generic;

namespace GEEK.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Carritos = new HashSet<Carrito>();
            Ordenes = new HashSet<Orden>();
        }

        public string IdUsuario { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string ApellidoUsuario { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string Direccion { get; set; } = null!;
        public string Departamento { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public string? IdRol { get; set; }

        public virtual Rol? IdRolNavigation { get; set; }
        public virtual ICollection<Carrito> Carritos { get; set; }
        public virtual ICollection<Orden> Ordenes { get; set; }
    }
}
