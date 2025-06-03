using System.Diagnostics;
using BacPeBune.Data;
using BacPeBune.Models;
using Microsoft.AspNetCore.Mvc;

namespace BacPeBune.Controllers
{
    public class LectiiController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public LectiiController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
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


        [Route("Lectii/{lesson_id}")]
        public IActionResult Index(int lesson_id)
        {

            var lesson = _context.Lessons.FirstOrDefault(l => l.LessonID == lesson_id);
            var quiz = _context.Quizzes.FirstOrDefault(q => q.LessonID == lesson_id);
            
            if (lesson == null)
            {
                return NotFound("Lesson not found.");
            }

        
            ViewBag.quizID = quiz;
            return View(lesson);
        }
    }
}
