using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEK.Models.ViewModels
{
    internal class ProductoVM
    {
        public Producto Producto { get; set; }

        public IEnumerable<SelectListItem>? ListaCategorias { get; set; }
        public IEnumerable<SelectListItem>? ListaMarcas { get; set; }

    }
}
