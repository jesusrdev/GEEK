using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEK.Models.ViewModels
{
    public class ImagenVM
    {
        public string IdImagen { get; set; }
        public IFormFile RutaImagen { get; set; }
        public string IdProducto {  get; set; }

        public IEnumerable<SelectListItem>? ListaProductos { get; set; }
    }
}
