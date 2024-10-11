using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Models;
using GEEK.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GEEK.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Area("Admin")]
    public class ImagenesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImagenesController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var nuevaImagen = new ImagenVM()
            {
                IdImagen = _contenedorTrabajo.Imagen.GenerarIdImagen(),        
                ListaProductos = _contenedorTrabajo.Producto.GetListaProductos()
            };

            return View(nuevaImagen);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ImagenVM imagenVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (archivos.Any())
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, "imagenes", "productos"); 

                    if (!Directory.Exists(subidas))
                    {
                        Directory.CreateDirectory(subidas); 
                    }

                    var extension = Path.GetExtension(archivos[0].FileName);
                    string rutaCompleta = Path.Combine(subidas, nombreArchivo + extension);

                    using (var fileStreams = new FileStream(rutaCompleta, FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    var imagen = new Imagen
                    {
                        IdImagen = _contenedorTrabajo.Imagen.GenerarIdImagen(),
                        IdProducto = imagenVM.IdProducto,
                        RutaImagen = "/imagenes/productos/" + nombreArchivo + extension // Ruta relativa para la base de datos y la vista
                    };

                    _contenedorTrabajo.Imagen.Add(imagen);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("RutaImagen", "Debes seleccionar una imagen");
                }
            }

            imagenVM.ListaProductos = _contenedorTrabajo.Producto.GetListaProductos();
            return View(imagenVM);
        }

        [HttpGet]
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagen = _contenedorTrabajo.Imagen.Get(id);
            if (imagen == null)
            {
                return NotFound();
            }

            var imagenVM = new ImagenVM
            {
                IdImagen = imagen.IdImagen,
                IdProducto = imagen.IdProducto,
                ListaProductos = _contenedorTrabajo.Producto.GetListaProductos()
            };

            ViewData["Imagen"] = imagen.RutaImagen;
            return View(imagenVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ImagenVM imagenVM)
        {
            if (ModelState.IsValid)
            {
                var imagen = _contenedorTrabajo.Imagen.Get(imagenVM.IdImagen);
                if (imagen == null)
                {
                    return NotFound();
                }

                if (imagenVM.RutaImagen != null)
                {
                    string rutaPrincipal = _hostingEnvironment.WebRootPath;
                    var extension = Path.GetExtension(imagenVM.RutaImagen.FileName);
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\productos");

                    using (var fileStream = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        imagenVM.RutaImagen.CopyTo(fileStream);
                    }

                    imagen.RutaImagen = @"\imagenes\productos\" + nombreArchivo + extension;
                }

                imagen.IdProducto = imagenVM.IdProducto;

                _contenedorTrabajo.Imagen.Update(imagen);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }

            imagenVM.ListaProductos = _contenedorTrabajo.Producto.GetListaProductos();

            return View(imagenVM);
        }

        #region Llamadas a la API - metodos que usa ajax

        [HttpGet]
        public IActionResult GetAll()
        {
            var imagenes = _contenedorTrabajo.Imagen.GetAll(includeProperties: "Producto").Select(p => new
            {
                idImagen = p.IdImagen,
                rutaImagen = p.RutaImagen,
                producto = new { nombreProducto = p.Producto.NombreProducto },
            }).ToList();

            return Json(new { data = imagenes });
        }

        public IActionResult Delete(string id)
        {
            var objFromDb = _contenedorTrabajo.Imagen.Get(id);

            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, objFromDb.RutaImagen.TrimStart('\\'));

            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }


            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error al borrar el articulo" });
            }

            _contenedorTrabajo.Imagen.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Articulo borrado correctamente" });

        }
        #endregion
    }
}
