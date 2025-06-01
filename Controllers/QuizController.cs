using System.Diagnostics;
using BacPeBune.Data;
using BacPeBune.Models;
using Microsoft.AspNetCore.Mvc;

namespace BacPeBune.Controllers
{
    public class QuizController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public QuizController(ILogger<HomeController> logger, ApplicationDbContext context)
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

        public IActionResult Show(int quizId, int? questionIndex = 0)
        {
            
            var questions = _context.Questions
            .Where(q => q.QuizID == quizId)
            .ToList();

            if (questions == null ) //|| questions.Count == 0
            {
                return NotFound("No questions found for this quiz.");
            }

            if (questionIndex < 0 || questionIndex >= questions.Count)
            {
                return NotFound("Invalid question index.");
            }

            var currentQuestion = questions[questionIndex ?? 0];

            var answers = _context.Answers
            .Where(a => a.QuestionID == currentQuestion.QuestionID)
            .ToList();

            
            ViewBag.Questions = questions;
            ViewBag.CurrentQuestion = currentQuestion;
            ViewBag.QuestionIndex = questionIndex ?? 0;
            ViewBag.Answers = answers;
            ViewBag.IsLastQuestion = (questionIndex == questions.Count - 1);

            return View(currentQuestion);
        }
        

    }
}
