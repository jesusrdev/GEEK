using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Models;
using GEEK.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GEEK.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IContenedorTrabajo _contenedorTrabajo;


        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            var HomeVM = new HomeVM()
            {
                Productos = _contenedorTrabajo.Producto.GetAll(),
                Categorias = _contenedorTrabajo.Categoria.GetAll(),
                Marcas = _contenedorTrabajo.Marca.GetAll(),
                Imagenes = _contenedorTrabajo.Imagen.GetAll()
            };

            ViewBag.IsHomeActive = "active";
            return View(HomeVM);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        #region Llamadas a la api

        [HttpGet]
        public IActionResult ObtenerProductosPorCategoria(string idCategoria)
        {
            var productos = _contenedorTrabajo.Producto
                .GetAll(filter: p => p.IdCategoria == idCategoria)
                .OrderByDescending(p => p.Precio) // Ordenar por precio en orden descendente
                .Take(9) // Tomar los primeros 9 productos
                .ToList(); // Ejecutar la consulta para obtener los productos primero

            var productosConImagen = new List<object>(); // Lista para almacenar los productos con sus imágenes

            foreach (var producto in productos)
            {
                // Obtener la primera imagen del producto usando el repositorio de imágenes
                var primeraImagen = _contenedorTrabajo.Imagen
                    .GetFirstOrDefault(i => i.IdProducto == producto.IdProducto);

                // Crear un objeto anónimo con los datos necesarios, incluyendo la ruta de la imagen
                var productoConImagenObj = new
                {
                    IdProducto = producto.IdProducto,
                    NombreProducto = producto.NombreProducto,
                    Precio = producto.Precio,
                    Descuento = producto.Descuento,
                    RutaImagen = primeraImagen?.RutaImagen // Utilizar operador de acceso condicional para manejar nulos
                                                           // Otros campos necesarios según tu aplicación
                };

                // Agregar el producto con imagen al resultado
                productosConImagen.Add(productoConImagenObj);
            }

            return Json(productosConImagen);


        }

        #endregion
    }
}
