using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GEEK.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CategoriasController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Crear Categoria
        [HttpGet]
        public IActionResult Create()
        {
            var nuevaCategoria = new Categoria();
            nuevaCategoria.IdCategoria = _contenedorTrabajo.Categoria.GenerarIdCategoria();

            return View(nuevaCategoria);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Create(categoria);

                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }



        // Editar categoria
        [HttpGet]
        public IActionResult Edit(string id)
        {
            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.Categoria.Get(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                // Logica para actualizar en la BD
                _contenedorTrabajo.Categoria.Update(categoria);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }


        #region Llamadas a la API - metodos que usa ajax
        [HttpGet]
        public IActionResult GetAll()
        {
            // Traer la lista de productos con el GetAll
            return Json(new {data = _contenedorTrabajo.Categoria.GetAll() });
        }

        #endregion
    }

}
