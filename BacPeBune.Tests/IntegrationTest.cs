using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using BacPeBune;
using BacPeBune.Data;
using Microsoft.EntityFrameworkCore;
using BacPeBune.Models;
public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public IntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task HomePage_ReturnsSuccess()
    {
        var response = await _client.GetAsync("/");
        response.EnsureSuccessStatusCode();
    }

    private ApplicationDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        return new ApplicationDbContext(options);
    }

    [Fact]
    public void CanInsertQuizAndQuestion()
    {
        using var context = GetInMemoryDbContext();
        var lesson = new Lesson { LessonID = 1, Title = "Test", Lector = 1, SubjectID = "Math", PdfLink = "link" };
        context.Lessons.Add(lesson);
        var quiz = new Quiz { QuizID = 1, Name = "Quiz", Reward = 5, LessonID = 1, lesson = lesson };
        context.Quizzes.Add(quiz);
        var question = new Question { QuestionID = 1, Text = "2+2=?", QuizID = 1, Quiz = quiz };
        context.Questions.Add(question);
        context.SaveChanges();

        Assert.Single(context.Quizzes);
        Assert.Single(context.Questions);
        Assert.Equal("Quiz", context.Quizzes.First().Name);
    }

    
}
