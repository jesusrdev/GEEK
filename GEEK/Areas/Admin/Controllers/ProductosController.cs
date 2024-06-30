using Microsoft.AspNetCore.Mvc;
using GEEK.Models.ViewModels;
using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Models;


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

        public IActionResult Details(string id)
        {
            var producto = _contenedorTrabajo.Producto.GetFirstOrDefault(p => p.IdProducto == id && p.EstadoProducto != "B", includeProperties: "Marca,Categoria");

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var nuevaProducto = new ProductoVM()
            {
                Producto = new Producto
                {
                    IdProducto = _contenedorTrabajo.Producto.GenerarIdProducto()
                },
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias(),
                ListaMarcas = _contenedorTrabajo.Marca.GetListaMarcas(),
            };
            
            return View(nuevaProducto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductoVM productoVM)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Producto.Create(productoVM.Producto);

                return RedirectToAction(nameof(Index));
            }

            return View(productoVM);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var producto = _contenedorTrabajo.Producto.GetFirstOrDefault(p => p.IdProducto == id && p.EstadoProducto != "B", includeProperties: "Marca,Categoria");

            if (producto == null)
            {
                return NotFound();
            }

            var productoVM = new ProductoVM
            {
                Producto = producto,
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias(),
                ListaMarcas = _contenedorTrabajo.Marca.GetListaMarcas()
            };

            return View(productoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductoVM productoVM)
        {
            if (ModelState.IsValid)
            {
                
                var producto = _contenedorTrabajo.Producto.Get(productoVM.Producto.IdProducto);

                if (producto == null || producto.EstadoProducto == "B")
                {
                    return NotFound(); 
                }


                producto.NombreProducto = productoVM.Producto.NombreProducto;
                producto.Precio = productoVM.Producto.Precio;
                producto.Descripcion = productoVM.Producto.Descripcion;
                producto.DescripcioGeneral = productoVM.Producto.DescripcioGeneral;
                producto.IdMarca = productoVM.Producto.IdMarca;
                producto.IdCategoria = productoVM.Producto.IdCategoria; 

                
                _contenedorTrabajo.Producto.Update(producto);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }
            productoVM.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias();
            productoVM.ListaMarcas = _contenedorTrabajo.Marca.GetListaMarcas();
            return View(productoVM);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var producto = _contenedorTrabajo.Producto.GetFirstOrDefault(p => p.IdProducto == id, includeProperties: "Marca,Categoria");
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var producto = _contenedorTrabajo.Producto.Get(id);
            if (producto == null)
            {
                return NotFound();
            }

            // Cambiar el estado a "B" en lugar de eliminar el producto
            producto.EstadoProducto = "B";
            _contenedorTrabajo.Producto.Update(producto);
            _contenedorTrabajo.Save();

            return RedirectToAction(nameof(Index));
        }





        // Para este controller se usara productoVM

        #region Llamadas a la API - metodos que usa ajax

        [HttpGet]
        public IActionResult GetAll()
        {
            var productos = _contenedorTrabajo.Producto.GetAll(p => p.EstadoProducto != "B", includeProperties: "Marca,Categoria").Select(p => new
            {
                idProducto = p.IdProducto,
                nombreProducto = p.NombreProducto,
                precio = p.Precio,
                marca = new { nombreMarca = p.Marca.NombreMarca },
                categoria = new { descripcionCategoria = p.Categoria.DescripcionCategoria },
                descripcion = p.Descripcion
            }).ToList();

            return Json(new { data = productos });
        }

        #endregion
    }
}
