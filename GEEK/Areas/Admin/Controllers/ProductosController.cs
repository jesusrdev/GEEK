using BlogCore.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GEEK.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductosController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostingEnvironment;
        }



        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        // Para este controller se usara productoVM

        #region Llamadas a la API - metodos que usa ajax

        public IActionResult GetAll()
        {
            // Traer la lista de productos con el GetAll
            return Json(new {});
        }

        #endregion
    }
}
