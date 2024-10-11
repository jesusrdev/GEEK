using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GEEK.Models
{
    public partial class Usuario : IdentityUser
    {
        public Usuario()
        {
            DetalleOrden = new HashSet<DetalleOrden>();
            Ordenes = new HashSet<Orden>();
        }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        public string ApellidoUsuario { get; set; } = null!;

        public string? DNI { get; set; } = null!;
        public DateTime? FechaRegistro { get; set; }
        public string? Direccion { get; set; } = null!;
        public string? Departamento { get; set; } = null!;
        public string? Pais { get; set; } = null!;

        
        public virtual ICollection<DetalleOrden>? DetalleOrden { get; set; }
        public virtual ICollection<Orden>? Ordenes { get; set; }
    }
}
