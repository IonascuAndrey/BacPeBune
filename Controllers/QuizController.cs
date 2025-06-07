using System.Diagnostics;
using BacPeBune.Data;
using BacPeBune.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


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
            ViewBag.GivenAnswers = string.Empty; // Initialize given answers as empty

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

            if (questionIndex >= questions.Count - 1)
            {
                var questionsId = questions.Select(q => q.QuestionID).ToList();
                string updatedGivenAnswersResult = string.IsNullOrEmpty(givenAnswers)
                    ? selectedAnswer.ToString()
                    : givenAnswers + "," + selectedAnswer;

                var givenAnswerIds = updatedGivenAnswersResult
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                var givenAnswersText = _context.Answers
                    .Where(a => givenAnswerIds.Contains(a.AnswerID))
                    .Select(a => a.Text)
                    .ToList();

                var correctAnswersIds = _context.Answers
                    .Where(a => a.IsCorrect && questionsId.Contains(a.QuestionID))
                    .Select(a => a.AnswerID)
                    .ToList();

                var correctAnswersTextResults = _context.Answers
                    .Where(a => correctAnswersIds.Contains(a.AnswerID))
                    .Select(a => a.Text)
                    .ToList();

                double percentage = (double)correctCount / questions.Count * 100;
                var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Questions = questions;
                ViewBag.Answers = answers;
                ViewBag.Percentage = correctCount / (double)questions.Count * 100;
                ViewBag.GivenAnswersIds = givenAnswerIds;
                ViewBag.CorrectAnswersIds = correctAnswersIds;
                ViewBag.GivenAnswersText = givenAnswersText;
                ViewBag.CorrectAnswersText = correctAnswersTextResults;

                if (percentage >= 50)
                {
                    
                    var Quiz = _context.Quizzes.FirstOrDefault(q => q.QuizID == quizId);
                    var UserReward = new UserReward
                    {
                        UserId = UserId,
                        User = _context.Users.FirstOrDefault(u => u.Id == UserId),
                        QuizId = quizId,
                        Quiz = Quiz,
                        Reward = Quiz.Reward,
                        Date = DateTime.Now
                    };
                    _context.UserRewards.Add(UserReward);
                    _context.SaveChanges();
                }

                var highestScoreSoFar = _context.UserQuizResults
                    .Where(user => user.UserId == UserId && user.QuizId == quizId)
                    .Select(user => user.Score);

                if (!highestScoreSoFar.Any())
                {
                    var userQuizResult = new UserQuizResult
                    {
                        UserId = UserId,
                        User = _context.Users.FirstOrDefault(u => u.Id == UserId),
                        QuizId = quizId,
                        Quiz = _context.Quizzes.FirstOrDefault(q => q.QuizID == quizId),
                        Score = (int)percentage
                    };
                    _context.UserQuizResults.Add(userQuizResult);
                }

                var maxScore = highestScoreSoFar.DefaultIfEmpty(0).Max();
                if (percentage >= maxScore)
                {
                    var userQuizResult = _context.UserQuizResults
                        .FirstOrDefault(user => user.UserId == UserId && user.QuizId == quizId);
                    userQuizResult.Score = (int)percentage;
                    _context.UserQuizResults.Update(userQuizResult);
                    _context.SaveChanges();
                }

                    
                return View("Results");
            }

            // Otherwise, show next question
            var nextQuestion = questions[questionIndex + 1];
            var nextAnswers = _context.Answers
                .Where(a => a.QuestionID == nextQuestion.QuestionID)
                .ToList();

            ViewBag.Questions = questions;
            ViewBag.Answers = nextAnswers; // <-- Now correct!
            ViewBag.QuestionIndex = questionIndex + 1;
            ViewBag.CorrectCount = correctCount;
            ViewBag.CorrectAnswerId = nextAnswers.FirstOrDefault(a => a.IsCorrect)?.AnswerID ?? 0;
            ViewBag.IsLastQuestion = (questionIndex + 1 == questions.Count - 1);

            // Update GivenAnswers as a comma-separated string
            string updatedGivenAnswers = string.IsNullOrEmpty(givenAnswers)
                ? selectedAnswer.ToString()
                : givenAnswers + "," + selectedAnswer;
            ViewBag.GivenAnswers = updatedGivenAnswers;

            var questionIds = _context.Questions
                    .Where(q => q.QuizID == quizId)
                    .Select(q => q.QuestionID)
                    .ToList();

            var correctAnswersText = _context.Answers
                .Where(a => a.IsCorrect && questionIds.Contains(a.QuestionID))
                .Select(a => a.Text)
                .ToList();
            ViewBag.CorrectAnswers = correctAnswersText;

            return View(nextQuestion);
        }
    }
}
        //[HttpGet]
        //     public IActionResult Results(int quizId, int correctCount, int totalQuestions, double percentage, string givenAnswers )
        // {
        //         ViewBag.CorrectCount = correctCount;
        //         ViewBag.TotalQuestions = totalQuestions;
        //         ViewBag.Percentage = percentage;

        //         var questions = _context.Questions
        //             .Where(q => q.QuizID == quizId)
        //             .ToList();
        //         ViewBag.Questions = questions;

        //         var questionIds = _context.Questions
        //             .Where(q => q.QuizID == quizId)
        //             .Select(q => q.QuestionID)
        //             .ToList();


        //         ViewBag.CorrectAnswers = _context.Answers
        //             .Where(a => a.IsCorrect && questionIds.Contains(a.QuestionID))
        //             .Select(a => a.Text)
        //             .ToList();


        //         _logger.LogInformation("Given answers: {GivenAnswers}", (object)(ViewBag.GivenAnswers as IEnumerable<int> ?? new List<int>()));
        //         _logger.LogInformation("Correct answers: {CorrectAnswers}", (object)(ViewBag.CorrectAnswers as IEnumerable<object> ?? new List<object>()));

        //         return View();
        //     }
        //}
    