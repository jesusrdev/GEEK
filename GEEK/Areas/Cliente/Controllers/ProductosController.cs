using Microsoft.AspNetCore.Mvc;

namespace GEEK.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.IsProductosActive = "active";

            return View();
        }
    }
}
