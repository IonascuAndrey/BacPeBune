using BacPeBune.Models;
using Xunit;
using System;
using BacPeBune.Controllers;
using Microsoft.AspNetCore.Mvc;

public class ModelTests
{
    [Fact]
    public void CanCreateQuiz()
    {
        var lesson = new Lesson { LessonID = 1, Title = "Test", Lector = 1, SubjectID = "Math", PdfLink = "https://google.com" };
        var quiz = new Quiz { QuizID = 1, Name = "Test Quiz", Reward = 10, LessonID = 1, lesson = lesson };
        Assert.Equal("Test Quiz", quiz.Name);
        Assert.Equal(10, quiz.Reward);
        Assert.Equal(lesson, quiz.lesson);
    }

    [Fact]
    public void CanCreateQuestion()
    {
        var quiz = new Quiz { QuizID = 1, Name = "Q", Reward = 1, LessonID = 1, lesson = new Lesson { LessonID = 1, Title = "T", Lector = 1, SubjectID = "S", PdfLink = "L" } };
        var question = new Question { QuestionID = 1, Text = "What is 2+2?", QuizID = 1, Quiz = quiz };
        Assert.Equal("What is 2+2?", question.Text);
        Assert.Equal(quiz, question.Quiz);
    }

    [Fact]
    public void CanCreateAnswer()
    {
        var question = new Question { QuestionID = 1, Text = "Q", QuizID = 1, Quiz = new Quiz { QuizID = 1, Name = "Q", Reward = 1, LessonID = 1, lesson = new Lesson { LessonID = 1, Title = "T", Lector = 1, SubjectID = "S", PdfLink = "L" } } };
        var answer = new Answer { AnswerID = 1, Text = "42", IsCorrect = true, QuestionID = 1, question = question };
        Assert.Equal("42", answer.Text);
        Assert.True(answer.IsCorrect);
        Assert.Equal(question, answer.question);
    }

    [Fact]
    public void CanCreateLesson()
    {
        var lesson = new Lesson { LessonID = 2, Title = "Lesson 2", Lector = 2, SubjectID = "Physics", PdfLink = "link2" };
        Assert.Equal(2, lesson.LessonID);
        Assert.Equal("Lesson 2", lesson.Title);
        Assert.Equal("Physics", lesson.SubjectID);
    }

    [Fact]
    public void CanCreateUserReward()
    {
        var quiz = new Quiz { QuizID = 1, Name = "Quiz", Reward = 10, LessonID = 1, lesson = new Lesson { LessonID = 1, Title = "T", Lector = 1, SubjectID = "S", PdfLink = "L" } };
        var user = new Microsoft.AspNetCore.Identity.IdentityUser { Id = "user1", Email = "test@example.com" };
        var userReward = new UserReward
        {
            UserRewardId = 1,
            UserId = "user1",
            User = user,
            QuizId = 1,
            Quiz = quiz,
            Reward = 10,
            Date = DateTime.Now
        };
        Assert.Equal("user1", userReward.UserId);
        Assert.Equal(10, userReward.Reward);
        Assert.Equal(quiz, userReward.Quiz);
        Assert.Equal(user, userReward.User);
    }

    [Fact]
    public void Lesson_RequiredFields()
    {
        var lesson = new Lesson { LessonID = 3, Title = "T", Lector = 1, SubjectID = "S", PdfLink = "L" };
        Assert.NotNull(lesson.Title);
        Assert.NotNull(lesson.SubjectID);
        Assert.NotNull(lesson.PdfLink);
    }

    [Fact]
    public void Quiz_RequiredFields()
    {
        var lesson = new Lesson { LessonID = 1, Title = "T", Lector = 1, SubjectID = "S", PdfLink = "L" };
        var quiz = new Quiz { QuizID = 2, Name = "Quiz2", Reward = 5, LessonID = 1, lesson = lesson };
        Assert.NotNull(quiz.Name);
        Assert.True(quiz.Reward > 0);
        Assert.Equal(lesson, quiz.lesson);
    }

    [Fact]
    public void Question_RequiredFields()
    {
        var quiz = new Quiz { QuizID = 1, Name = "Quiz", Reward = 1, LessonID = 1, lesson = new Lesson { LessonID = 1, Title = "T", Lector = 1, SubjectID = "S", PdfLink = "L" } };
        var question = new Question { QuestionID = 2, Text = "Q2", QuizID = 1, Quiz = quiz };
        Assert.NotNull(question.Text);
        Assert.Equal(quiz, question.Quiz);
    }

    [Fact]
    public void Answer_RequiredFields()
    {
        var question = new Question { QuestionID = 1, Text = "Q", QuizID = 1, Quiz = new Quiz { QuizID = 1, Name = "Q", Reward = 1, LessonID = 1, lesson = new Lesson { LessonID = 1, Title = "T", Lector = 1, SubjectID = "S", PdfLink = "L" } } };
        var answer = new Answer { AnswerID = 2, Text = "A2", IsCorrect = false, QuestionID = 1, question = question };
        Assert.NotNull(answer.Text);
        Assert.False(answer.IsCorrect);
        Assert.Equal(question, answer.question);
    }

    [Fact]
    public void UserReward_RequiredFields()
    {
        var quiz = new Quiz { QuizID = 1, Name = "Quiz", Reward = 10, LessonID = 1, lesson = new Lesson { LessonID = 1, Title = "T", Lector = 1, SubjectID = "S", PdfLink = "L" } };
        var user = new Microsoft.AspNetCore.Identity.IdentityUser { Id = "user2", Email = "test2@example.com" };
        var userReward = new UserReward
        {
            UserRewardId = 2,
            UserId = "user2",
            User = user,
            QuizId = 1,
            Quiz = quiz,
            Reward = 20,
            Date = DateTime.Now
        };
        Assert.Equal("user2", userReward.UserId);
        Assert.Equal(20, userReward.Reward);
        Assert.Equal(quiz, userReward.Quiz);
        Assert.Equal(user, userReward.User);
    }

    [Fact]
    public void Lesson_CanSetAndGetProperties()
    {
        var lesson = new Lesson { LessonID = 10, Title = "Algebra", Lector = 5, SubjectID = "Math", PdfLink = "algebra.pdf" };
        Assert.Equal(10, lesson.LessonID);
        Assert.Equal("Algebra", lesson.Title);
        Assert.Equal(5, lesson.Lector);
        Assert.Equal("Math", lesson.SubjectID);
        Assert.Equal("algebra.pdf", lesson.PdfLink);
    }

    [Fact]
    public void Quiz_CanSetAndGetProperties()
    {
        var lesson = new Lesson { LessonID = 11, Title = "Geometry", Lector = 6, SubjectID = "Math", PdfLink = "geometry.pdf" };
        var quiz = new Quiz { QuizID = 3, Name = "GeoQuiz", Reward = 15, LessonID = 11, lesson = lesson };
        Assert.Equal(3, quiz.QuizID);
        Assert.Equal("GeoQuiz", quiz.Name);
        Assert.Equal(15, quiz.Reward);
        Assert.Equal(11, quiz.LessonID);
        Assert.Equal(lesson, quiz.lesson);
    }

    [Fact]
    public void Question_CanSetAndGetProperties()
    {
        var quiz = new Quiz { QuizID = 4, Name = "TestQuiz", Reward = 5, LessonID = 12, lesson = new Lesson { LessonID = 12, Title = "Test", Lector = 7, SubjectID = "Math", PdfLink = "test.pdf" } };
        var question = new Question { QuestionID = 5, Text = "Sample?", QuizID = 4, Quiz = quiz };
        Assert.Equal(5, question.QuestionID);
        Assert.Equal("Sample?", question.Text);
        Assert.Equal(4, question.QuizID);
        Assert.Equal(quiz, question.Quiz);
    }

    [Fact]
    public void Answer_CanSetAndGetProperties()
    {
        var question = new Question { QuestionID = 6, Text = "Q6", QuizID = 5, Quiz = new Quiz { QuizID = 5, Name = "Q5", Reward = 5, LessonID = 13, lesson = new Lesson { LessonID = 13, Title = "T", Lector = 8, SubjectID = "S", PdfLink = "L" } } };
        var answer = new Answer { AnswerID = 7, Text = "A7", IsCorrect = true, QuestionID = 6, question = question };
        Assert.Equal(7, answer.AnswerID);
        Assert.Equal("A7", answer.Text);
        Assert.True(answer.IsCorrect);
        Assert.Equal(6, answer.QuestionID);
        Assert.Equal(question, answer.question);
    }

    [Fact]
    public void UserReward_CanSetAndGetProperties()
    {
        var quiz = new Quiz { QuizID = 6, Name = "Quiz6", Reward = 30, LessonID = 14, lesson = new Lesson { LessonID = 14, Title = "T", Lector = 9, SubjectID = "S", PdfLink = "L" } };
        var user = new Microsoft.AspNetCore.Identity.IdentityUser { Id = "user3", Email = "test3@example.com" };
        var userReward = new UserReward
        {
            UserRewardId = 3,
            UserId = "user3",
            User = user,
            QuizId = 6,
            Quiz = quiz,
            Reward = 30,
            Date = DateTime.Now
        };
        Assert.Equal(3, userReward.UserRewardId);
        Assert.Equal("user3", userReward.UserId);
        Assert.Equal(user, userReward.User);
        Assert.Equal(6, userReward.QuizId);
        Assert.Equal(quiz, userReward.Quiz);
        Assert.Equal(30, userReward.Reward);
    }

    [Fact]
    public void Lesson_Title_IsRequired()
    {
        var lesson = new Lesson { LessonID = 15, Title = "Required", Lector = 10, SubjectID = "Math", PdfLink = "required.pdf" };
        Assert.False(string.IsNullOrEmpty(lesson.Title));
    }

    [Fact]
    public void Quiz_Name_IsRequired()
    {
        var lesson = new Lesson { LessonID = 16, Title = "T", Lector = 11, SubjectID = "S", PdfLink = "L" };
        var quiz = new Quiz { QuizID = 7, Name = "RequiredQuiz", Reward = 10, LessonID = 16, lesson = lesson };
        Assert.False(string.IsNullOrEmpty(quiz.Name));
    }

    [Fact]
    public void Question_Text_IsRequired()
    {
        var quiz = new Quiz { QuizID = 8, Name = "Q8", Reward = 8, LessonID = 17, lesson = new Lesson { LessonID = 17, Title = "T", Lector = 12, SubjectID = "S", PdfLink = "L" } };
        var question = new Question { QuestionID = 8, Text = "RequiredText", QuizID = 8, Quiz = quiz };
        Assert.False(string.IsNullOrEmpty(question.Text));
    }

    [Fact]
    public void Answer_Text_IsRequired()
    {
        var question = new Question { QuestionID = 9, Text = "Q9", QuizID = 9, Quiz = new Quiz { QuizID = 9, Name = "Q9", Reward = 9, LessonID = 18, lesson = new Lesson { LessonID = 18, Title = "T", Lector = 13, SubjectID = "S", PdfLink = "L" } } };
        var answer = new Answer { AnswerID = 10, Text = "RequiredAnswer", IsCorrect = false, QuestionID = 9, question = question };
        Assert.False(string.IsNullOrEmpty(answer.Text));
    }

    [Fact]
    public void UserReward_Quiz_IsRequired()
    {
        var quiz = new Quiz { QuizID = 10, Name = "Quiz10", Reward = 10, LessonID = 19, lesson = new Lesson { LessonID = 19, Title = "T", Lector = 14, SubjectID = "S", PdfLink = "L" } };
        var user = new Microsoft.AspNetCore.Identity.IdentityUser { Id = "user4", Email = "test4@example.com" };
        var userReward = new UserReward
        {
            UserRewardId = 4,
            UserId = "user4",
            User = user,
            QuizId = 10,
            Quiz = quiz,
            Reward = 40,
            Date = DateTime.Now
        };
        Assert.NotNull(userReward.Quiz);
    }

    [Fact]
    public void UserReward_User_IsRequired()
    {
        var quiz = new Quiz { QuizID = 11, Name = "Quiz11", Reward = 11, LessonID = 20, lesson = new Lesson { LessonID = 20, Title = "T", Lector = 15, SubjectID = "S", PdfLink = "L" } };
        var user = new Microsoft.AspNetCore.Identity.IdentityUser { Id = "user5", Email = "test5@example.com" };
        var userReward = new UserReward
        {
            UserRewardId = 5,
            UserId = "user5",
            User = user,
            QuizId = 11,
            Quiz = quiz,
            Reward = 50,
            Date = DateTime.Now
        };
        Assert.NotNull(userReward.User);
    }

    [Fact]
    public void QuizController_Index_ReturnsViewResult()
    {
        // Arrange
        var logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<BacPeBune.Controllers.HomeController>();
        var dbContext = new BacPeBune.Data.ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<BacPeBune.Data.ApplicationDbContext>());
        var controller = new QuizController(logger, dbContext);

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void QuizController_RouteToIndex()
    {
        // Arrange
        var logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<BacPeBune.Controllers.HomeController>();
        var dbContext = new BacPeBune.Data.ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<BacPeBune.Data.ApplicationDbContext>());
        var controller = new QuizController(logger, dbContext);

        // Simulate route data
        controller.ControllerContext = new ControllerContext
        {
            RouteData = new Microsoft.AspNetCore.Routing.RouteData()
        };

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    
}