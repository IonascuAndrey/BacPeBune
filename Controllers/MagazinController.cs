using Microsoft.AspNetCore.Mvc;

namespace BacPeBune.Controllers
{
    public class MagazinController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Puncte = 123; // Vei aduce punctele reale din DB
            return View();
        }
    }
}
