﻿using GEEK.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GEEK.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsuariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public UsuariosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }


        [HttpGet]
        public IActionResult Index()
        {
                // Obtener todos los usuarios excepto el que esta logueado par no bloquearse asi mismo
                var claimsIdentity = (ClaimsIdentity)this.User.Identity; //Obtener la informacion del usuario actual

                var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                return View(_contenedorTrabajo.Usuario.GetAll(u => u.Id != usuarioActual.Value));
        }


        [HttpGet]
        public IActionResult Bloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _contenedorTrabajo.Usuario.BloquearUsuario(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Desbloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _contenedorTrabajo.Usuario.DesbloquearUsuario(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
