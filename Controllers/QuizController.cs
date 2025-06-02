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

            if (questions == null || questions.Count == 0) //|| questions.Count == 0
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

            var correctAnswer = answers.FirstOrDefault(a => a.IsCorrect);


            ViewBag.Questions = questions;
            ViewBag.CurrentQuestion = currentQuestion;
            ViewBag.QuestionIndex = questionIndex ?? 0;
            ViewBag.Answers = answers;
            ViewBag.IsLastQuestion = (questionIndex == questions.Count - 1);
            ViewBag.CorrectAnswerId = correctAnswer?.AnswerID ?? 0;
            ViewBag.CorrectCount = (ViewBag.CorrectCount != null) ?? 0;

            return View(currentQuestion);
        }

        [HttpPost]
        public IActionResult Show(int quizId, int questionIndex, int correctCount, string givenAnswers, int selectedAnswer)
        {
            var questions = _context.Questions.Where(q => q.QuizID == quizId).ToList();
            if (questionIndex < 0 || questionIndex >= questions.Count)
                return RedirectToAction("Results", new { quizId, correctCount, totalQuestions = questions.Count });

            var currentQuestion = questions[questionIndex];
            var answers = _context.Answers.Where(a => a.QuestionID == currentQuestion.QuestionID).ToList();
            var correctAnswer = answers.FirstOrDefault(a => a.IsCorrect);



            // Check if the answer is correct
            if (selectedAnswer == (correctAnswer?.AnswerID ?? -1))
            {
                correctCount++;
                ViewBag.WasCorrect = true;
            }
            else
            {
                ViewBag.WasCorrect = false;
                ViewBag.CorrectAnswerText = correctAnswer?.Text;
            }

            // If last question, go to results
            if (questionIndex >= questions.Count - 1)
            {
                var percentage = (double)correctCount / questions.Count * 100;
                return RedirectToAction("Results", new { quizId, correctCount, totalQuestions = questions.Count, percentage = percentage });
            }

            // Otherwise, show next question
            ViewBag.Questions = questions;
            ViewBag.Answers = answers;
            ViewBag.QuestionIndex = questionIndex + 1;
            ViewBag.CorrectCount = correctCount;
            ViewBag.CorrectAnswerId = correctAnswer?.AnswerID ?? 0;
            ViewBag.IsLastQuestion = (questionIndex + 1 == questions.Count - 1);
            if (ViewBag.GivenAnswers != null)
            {
                ViewBag.GivenAnswers = ViewBag.GivenAnswers.append(selectedAnswer);
            } else {
                ViewBag.GivenAnswers = new List<String>();
            }

            var nextQuestion = questions[questionIndex + 1];

            return View(nextQuestion);
        }


        [HttpPost]
        public IActionResult Results(int quizId, int questionIndex, int cc, string userAnswers)
        {
            var questions = _context.Questions
                .Where(q => q.QuizID == quizId)
                .ToList();

            var questionsId = questions.Select(q => q.QuestionID).ToList();

            var answers = _context.Answers
                .Where(a => questionsId.Contains(a.QuestionID))
                .ToList();

            var givenIds = (userAnswers ?? "")
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(id => int.TryParse(id, out var val) ? val : -1)
                .ToList();


            ViewBag.Questions = questions;
            ViewBag.Answers = answers;
            ViewBag.Percentage = cc / (double)questions.Count * 100;
            ViewBag.GivenAnswers = userAnswers;

            double percentage = (double)cc / questions.Count * 100;
            return RedirectToAction("Results", new { quizId, correctCount = cc, totalQuestions = questions.Count, percentage, givenAnswers = userAnswers });
        }

        [HttpGet]
        public IActionResult Results(int quizId, int correctCount, int totalQuestions, double percentage, string givenAnswers )
    {
            ViewBag.CorrectCount = correctCount;
            ViewBag.TotalQuestions = totalQuestions;
            ViewBag.Percentage = percentage;
            ViewBag.GivenAnswers = givenAnswers;

            var questions = _context.Questions
                .Where(q => q.QuizID == quizId)
                .ToList();
            ViewBag.Questions = questions;

            var questionIds = _context.Questions
                .Where(q => q.QuizID == quizId)
                .Select(q => q.QuestionID)
                .ToList();


            ViewBag.CorrectAnswers = _context.Answers
                .Where(a => a.IsCorrect && questionIds.Contains(a.QuestionID))
                .ToList();
            return View();
        }
    }
}
