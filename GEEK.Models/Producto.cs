using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GEEK.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleOrden = new HashSet<DetalleOrden>();
            Imagenes = new HashSet<Imagen>();
        }

        [Key]
        [Display(Name = "Id")]
        public string IdProducto { get; set; } = null!;

        [Required(ErrorMessage = "Producto Requerido")]
        [Display(Name = "Producto")]
        public string NombreProducto { get; set; } = null!;

        [Required(ErrorMessage = "Descripcion Requerido")]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Display(Name = "Descripción General")]
        public string? DescripcioGeneral { get; set; }

        [Required(ErrorMessage = "Precio Requerido")]
        [Display(Name = "Precio")]
        public decimal? Precio { get; set; }

        [Required(ErrorMessage = "Stock Requerido")]
        [Display(Name = "Stock")]
        public int? StockProducto { get; set; }

        [Display(Name = "Descuento")]
        public decimal? Descuento { get; set; }

        [Display(Name = "Marca")]
        public string? IdMarca { get; set; }

        [Display(Name = "Categoria")]
        public string? IdCategoria { get; set; }

        [Display(Name = "Estado")]
        public string? EstadoProducto { get; set; }

        [ForeignKey("IdCategoria")]
        public virtual Categoria? Categoria { get; set; }

        [ForeignKey("IdMarca")]
        public virtual Marca? Marca { get; set; }
        public virtual ICollection<DetalleOrden> DetalleOrden { get; set; }

        public virtual ICollection<Imagen> Imagenes { get; set; }
    }
}
