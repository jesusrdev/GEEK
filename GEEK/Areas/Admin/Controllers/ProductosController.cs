using Microsoft.AspNetCore.Mvc;
using GEEK.Models.ViewModels;
using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Models;
using Microsoft.AspNetCore.Authorization;


namespace GEEK.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador")]
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
            var producto = _contenedorTrabajo.Producto.GetFirstOrDefault(
                p => p.IdProducto == id && p.EstadoProducto != "B",
                includeProperties: "Marca,Categoria");

            if (producto == null)
            {
                return NotFound();
            }

            var imagenes = _contenedorTrabajo.Imagen.GetAll(img => img.IdProducto == id).ToList();

            var productoVM = new ProductoVM
            {
                IdProducto = producto.IdProducto,
                NombreProducto = producto.NombreProducto,
                Descripcion = producto.Descripcion,
                DescripcioGeneral = producto.DescripcioGeneral,
                Precio = producto.Precio,
                StockProducto = producto.StockProducto,
                Descuento = producto.Descuento,
                IdMarca = producto.IdMarca,
                IdCategoria = producto.IdCategoria,
                EstadoProducto = producto.EstadoProducto,
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias(),
                ListaMarcas = _contenedorTrabajo.Marca.GetListaMarcas(),
                Imagenes = imagenes  
            };

            return View(producto); 
        }


        [HttpGet]
        public IActionResult Create()
        {
            var nuevaProducto = new ProductoVM()
            {
                IdProducto = _contenedorTrabajo.Producto.GenerarIdProducto(),
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

                var producto = new Producto
                {
                    IdProducto = productoVM.IdProducto,
                    EstadoProducto = "A",
                    NombreProducto = productoVM.NombreProducto,
                    Precio = productoVM.Precio,
                    StockProducto = productoVM.StockProducto,
                    Descuento = productoVM.Descuento,
                    Descripcion = productoVM.Descripcion,
                    DescripcioGeneral = productoVM.DescripcioGeneral,
                    IdCategoria = productoVM.IdCategoria,
                    IdMarca = productoVM.IdMarca
                };

                _contenedorTrabajo.Producto.Add(producto);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }

            productoVM.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias();
            productoVM.ListaMarcas = _contenedorTrabajo.Marca.GetListaMarcas();
            return View(productoVM);
        }


        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var producto = _contenedorTrabajo.Producto.GetFirstOrDefault(p => p.IdProducto == id, includeProperties: "Imagenes");
            if (producto == null)
            {
                return NotFound();
            }

            var productoVM = new ProductoVM
            {
                IdProducto = producto.IdProducto,
                NombreProducto = producto.NombreProducto,
                Precio = producto.Precio,
                StockProducto = producto.StockProducto,
                Descuento = producto.Descuento,
                Descripcion = producto.Descripcion,
                DescripcioGeneral = producto.DescripcioGeneral,
                IdCategoria = producto.IdCategoria,
                IdMarca = producto.IdMarca,
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias(),
                ListaMarcas = _contenedorTrabajo.Marca.GetListaMarcas(),
            };

            return View(productoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductoVM productoVM)
        {
            if (ModelState.IsValid)
            {
                var producto = _contenedorTrabajo.Producto.GetFirstOrDefault(p => p.IdProducto == productoVM.IdProducto, includeProperties: "Imagenes");

                if (producto == null)
                {
                    return NotFound();
                }

                producto.NombreProducto = productoVM.NombreProducto;
                producto.Precio = productoVM.Precio;
                producto.StockProducto = productoVM.StockProducto;
                producto.Descuento = productoVM.Descuento;
                producto.Descripcion = productoVM.Descripcion;
                producto.DescripcioGeneral = productoVM.DescripcioGeneral;
                producto.IdCategoria = productoVM.IdCategoria;
                producto.IdMarca = productoVM.IdMarca;

                try
                {
                    _contenedorTrabajo.Producto.Update(producto);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error al editar el producto: {ex.Message}");
                }
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
