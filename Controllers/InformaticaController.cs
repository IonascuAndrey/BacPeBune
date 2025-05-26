using System.Diagnostics;
using BacPeBune.Models;
using Microsoft.AspNetCore.Mvc;

namespace BacPeBune.Controllers
{
    public class InformaticaController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public InformaticaController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ReactApp()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "react-mindmap-app", "index.html");
            return PhysicalFile(filePath, "text/html");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
