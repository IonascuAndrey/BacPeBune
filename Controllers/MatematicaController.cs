using System.Diagnostics;
using BacPeBune.Models;
using Microsoft.AspNetCore.Mvc;

namespace BacPeBune.Controllers
{
    public class MatematicaController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public MatematicaController(ILogger<HomeController> logger)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ReactApp()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "react-mindmap-app", "index.html");
            Console.WriteLine($"Serving React app from: {filePath}");
            return PhysicalFile(filePath, "text/html");
        }
    }
}
