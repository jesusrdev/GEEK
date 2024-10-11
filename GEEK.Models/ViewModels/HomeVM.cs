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
    public class HomeVM
    {
        public Producto? Producto { get; set; }
        public Imagen? ImagenP { get; set; }
        public IEnumerable<Producto>? Productos { get; set; }
        public IEnumerable<Categoria>? Categorias { get; set; }
        public IEnumerable<Marca>? Marcas { get; set; }
        public IEnumerable<Imagen>? Imagenes { get; set; }

    }
}
