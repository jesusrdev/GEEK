using GEEK.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEK.AccesoDatos.Data.Repository.IRepository
{
    public interface IProductoRepository : IRepository<Producto>
    {
        void Create(Producto producto);
        void Update(Producto producto);
        string GenerarIdProducto();
        public IEnumerable<SelectListItem> GetListaProductos();
    }
}
