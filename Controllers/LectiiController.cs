using System.Diagnostics;
using BacPeBune.Models;
using Microsoft.AspNetCore.Mvc;

namespace BacPeBune.Controllers
{
    public class LectiiController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public LectiiController(ILogger<HomeController> logger)
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

        public IActionResult Index(String lesson_name)
        {
            return Index(lesson_name);
        }
    }
}
