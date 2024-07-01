﻿using GEEK.AccesoDatos.Data.Repository.IRepository;
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
                Marcas = _contenedorTrabajo.Marca.GetAll()
            };

            ViewBag.IsHomeActive = "active";
            return View(HomeVM);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
