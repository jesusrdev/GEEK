using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Models;
using GEEK.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        public IActionResult Detalle(string idproducto)
        {
            if (string.IsNullOrEmpty(idproducto))
            {
                return NotFound();
            }

            var producto = _contenedorTrabajo.Producto.GetFirstOrDefault(
                p => p.IdProducto == idproducto,
                includeProperties: "Imagenes,Categoria"
            );

            var imagen = _contenedorTrabajo.Imagen.GetFirstOrDefault(
                i => i.IdProducto== idproducto);

            if (producto == null)
            {
                return NotFound();
            }

            var productosRecomendados = _contenedorTrabajo.Producto.GetAll(
                p => p.IdCategoria == producto.IdCategoria && p.IdProducto != idproducto
            ).Take(3).ToList();

            foreach (var recomendado in productosRecomendados)
            {
                recomendado.Imagenes = _contenedorTrabajo.Imagen.GetAll(i => i.IdProducto == recomendado.IdProducto).ToList();
            }

            var homeVM = new HomeVM
            {
                Producto = producto,
                ImagenP = imagen,
                Imagenes = producto.Imagenes,
                Categorias = _contenedorTrabajo.Categoria.GetAll(),
                Marcas = _contenedorTrabajo.Marca.GetAll(),
                Productos = productosRecomendados
            };

            return View(homeVM);
        }



        #region Llamada a las apis

        [HttpGet]
        public IActionResult FiltrarProductos(string searchString, string idMarca, string categorias, int page = 1, int pageSize = 12)
        {

            var query = _contenedorTrabajo.Producto.GetAll();

            // Aplicar filtro de búsqueda
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.NombreProducto.ToLower().Contains(searchString.ToLower()));
            }

            // Aplicar filtro de marca
            if (!string.IsNullOrEmpty(idMarca) && idMarca != "todas")
            {
                query = query.Where(p => p.IdMarca == idMarca);
            }

            // Filtro de categorías
            if (!string.IsNullOrEmpty(categorias))
            {
                var categoriasLista = JsonConvert.DeserializeObject<List<string>>(categorias);
                if (categoriasLista != null && categoriasLista.Any())
                {
                    query = query.Where(p => categoriasLista.Contains(p.IdCategoria));
                }
            }

            // Calcular el número total de productos y páginas
            var totalProductos = query.Count();
            var totalPaginas = (int)Math.Ceiling((double)totalProductos / pageSize);

            // Aplicar paginación
            var productos = query
                .OrderByDescending(p => p.Precio)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var productosConImagen = new List<object>();
            foreach (var producto in productos)
            {
                var primeraImagen = _contenedorTrabajo.Imagen
                    .GetFirstOrDefault(i => i.IdProducto == producto.IdProducto);

                var productoConImagenObj = new
                {
                    IdProducto = producto.IdProducto,
                    NombreProducto = producto.NombreProducto,
                    Precio = producto.Precio,
                    Descuento = producto.Descuento,
                    RutaImagen = primeraImagen?.RutaImagen
                };

                productosConImagen.Add(productoConImagenObj);
            }

            var resultado = new
            {
                Productos = productosConImagen,
                TotalPaginas = totalPaginas,
                PaginaActual = page,
                TotalProductos = totalProductos
            };

            return Json(resultado);
        }

        #endregion
    }
}
