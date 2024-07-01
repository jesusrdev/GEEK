using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GEEK.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class ProductosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ProductosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index(string idMarca)
        {
            var HomeVM = new HomeVM()
            {
                Productos = _contenedorTrabajo.Producto.GetAll(),
                Categorias = _contenedorTrabajo.Categoria.GetAll(),
                Marcas = _contenedorTrabajo.Marca.GetAll()
            };

            ViewData["idMarca"] = idMarca;

            ViewBag.IsProductosActive = "active";

            return View(HomeVM);
        }
    }
}
