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
    public class MarcaVM
    {
        [Required(ErrorMessage = "Id Requerida")]
        [Display(Name = "ID")]
        public string IdMarca { get; set; }


        [Required(ErrorMessage = "Marca Requerida")]
        [Display(Name = "Marca")]
        public string NombreMarca { get; set; }

        [Required(ErrorMessage = "Imagen Requerida")]
        [Display(Name = "Imagen")]
        public IFormFile? RutaImagen { get; set; }

    }
}