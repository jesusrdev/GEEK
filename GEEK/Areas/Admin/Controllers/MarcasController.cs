using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Models;
using GEEK.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GEEK.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Area("Admin")]
    public class MarcasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MarcasController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
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
            var nuevaMarca = new MarcaVM();
            nuevaMarca.IdMarca = _contenedorTrabajo.Marca.GenerarIdMarca();

            return View(nuevaMarca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MarcaVM marcaVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (archivos.Any())
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\marcas");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    var marca = new Marca
                    {
                        IdMarca = marcaVM.IdMarca,
                        NombreMarca = marcaVM.NombreMarca,
                        RutaImagen = @"\imagenes\marcas\" + nombreArchivo + extension
                    };

                    _contenedorTrabajo.Marca.Add(marca);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("ArchivoImagen", "Debes seleccionar una imagen");
                }
            }

            return View(marcaVM);
        }

        [HttpGet]
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _contenedorTrabajo.Marca.Get(id);
            if (marca == null)
            {
                return NotFound();
            }

            var marcaVM = new MarcaVM
            {
                IdMarca = marca.IdMarca,
                NombreMarca = marca.NombreMarca
            };

            ViewData["Imagen"] = marca.RutaImagen;
            return View(marcaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MarcaVM marcaVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var marca = _contenedorTrabajo.Marca.Get(marcaVM.IdMarca);
                if (marca == null)
                {
                    return NotFound();
                }

                if (archivos.Any())
                {
                    // Eliminar imagen anterior si existe
                    if (!string.IsNullOrEmpty(marca.RutaImagen))
                    {
                        var rutaImagenAnterior = Path.Combine(rutaPrincipal, marca.RutaImagen.TrimStart('\\', '/'));
                        if (System.IO.File.Exists(rutaImagenAnterior))
                        {
                            System.IO.File.Delete(rutaImagenAnterior);
                        }
                    }

                    // Subir nueva imagen
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\marcas");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        await archivos[0].CopyToAsync(fileStreams);
                    }

                    marca.RutaImagen = @"\imagenes\marcas\" + nombreArchivo + extension;
                }

                marca.NombreMarca = marcaVM.NombreMarca;

                _contenedorTrabajo.Marca.Update(marca);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(marcaVM);
        }
        #region Llamadas a la API - metodos que usa ajax
        [HttpGet]
        public IActionResult GetAll()
        {
            // Traer la lista de productos con el GetAll
            return Json(new { data = _contenedorTrabajo.Marca.GetAll() });
        }

        #endregion
    }
}
