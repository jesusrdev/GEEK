using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEK.Models.ViewModels
{
    public class ProductoVM
    {
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
        public IEnumerable<SelectListItem>? ListaCategorias { get; set; }
        public IEnumerable<SelectListItem>? ListaMarcas { get; set; }
        public List<Imagen>? Imagenes { get; set; }

    }
}
