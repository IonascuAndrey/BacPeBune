using BacPeBune.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.DataProtection;
using System.IO;                          
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using System.Data.Common;
using MySqlConnector;  
using BacPeBune.Models;
using BacPeBune.Hubs;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
 
DbConnection connection = new MySqlConnection(connectionString);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 0)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,           // Number of retry attempts
            maxRetryDelay: TimeSpan.FromSeconds(10), // Max delay between retries
            errorNumbersToAdd: null     // You can specify MySQL error numbers to retry on, or leave null for defaults
        )
    )
);
    
Console.WriteLine($"Connection string is: {connectionString}");

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();

// Semantic Kernel Configuration for Ollama
var ollamaEndpoint = builder.Configuration["LLM:Endpoint"] ?? "http://host.docker.internal:11434";
var ollamaModelId = builder.Configuration["LLM:ModelId"] ?? "RoLlama3.1-8b-Instruct-DPO-GGUF";

#pragma warning disable SKEXP0070
builder.Services.AddKernel()
    .AddOllamaChatCompletion(modelId: ollamaModelId, endpoint: new Uri(ollamaEndpoint));
#pragma warning restore SKEXP0070


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    var sql = File.ReadAllText("Data/Init.sql");
    try
    {
        context.Database.EnsureCreated();

        if (!context.Lessons.Any())
        {
            context.Database.ExecuteSqlRaw(sql);
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while initializing the database.");
    }
    // try
    // {
    //     context.Database.Migrate();

    //     if (!context.Lessons.Any())
    //     {
    //         context.Lessons.Add(
    //             new Lesson
    //             {
    //                 LessonID = 1,
    //                 Title = "Introduction to Programming",
    //                 Lector = 1,
    //                 SubjectID = "Informatica",
    //                 PdfLink = "https://x.com"
    //             }
    //         );
    //     }

    //     if (!context.Quizzes.Any()) {

    //         context.Quizzes.Add(
    //             new Quiz
    //             {
    //                 QuizID = 1,
    //                 Name = "Quiz 1 for Lesson 1",
    //                 Reward = 10,
    //                 LessonID = 1,
    //                 lesson = context.Lessons.FirstOrDefault(l => l.LessonID == 1),
    //             }
    //         );
    //     }

    //     if (!context.Questions.Any()) {
    //         context.Questions.Add(
    //             new Question
    //             {
    //                 QuestionID = 1,
    //                 Text = "What is the main purpose of programming?",
    //                 QuizID = 1,
    //                 Quiz = context.Quizzes.FirstOrDefault(q => q.QuizID == 1)
    //             }
    //         );

    //         context.Questions.Add(
    //             new Question
    //             {
    //                 QuestionID = 2,
    //                 Text = "What is the purpose of algorithms?",
    //                 QuizID = 1,
    //                 Quiz = context.Quizzes.FirstOrDefault(q => q.QuizID == 1)
    //             }
    //         );
    //     }

    //     if (!context.Answers.Any()) {
    //         context.Answers.Add(
    //                 new Answer
    //                 {
    //                     AnswerID = 1,
    //                     Text = "To create software applications",
    //                     QuestionID = 1,
    //                     IsCorrect = true,
    //                     question = context.Questions.FirstOrDefault(q => q.QuestionID == 1)
    //                 }
    //             );

    //         context.Answers.Add(
    //             new Answer
    //             {
    //                 AnswerID = 2,
    //                 Text = "To write documentation",
    //                 QuestionID = 1,
    //                 IsCorrect = false,
    //                 question = context.Questions.FirstOrDefault(q => q.QuestionID == 1)
    //             }
    //         );

    //         context.Answers.Add(
    //             new Answer
    //             {
    //                 AnswerID = 3,
    //                 Text = "To create algorithms",
    //                 QuestionID = 2,
    //                 IsCorrect = true,
    //                 question = context.Questions.FirstOrDefault(q => q.QuestionID == 2)
    //             }
    //         );

    //         context.Answers.Add(
    //             new Answer
    //             {
    //                 AnswerID = 4,
    //                 Text = "To write code",
    //                 QuestionID = 2,
    //                 IsCorrect = false,
    //                 question = context.Questions.FirstOrDefault(q => q.QuestionID == 2)
    //             }
    //         );

    //         context.Answers.Add(
    //             new Answer
    //             {
    //                 AnswerID = 5,
    //                 Text = "To create user interfaces",
    //                 QuestionID = 2,
    //                 IsCorrect = false,
    //                 question = context.Questions.FirstOrDefault(q => q.QuestionID == 2)
    //             }
    //         );

    //     }

    //     context.SaveChanges();
    // }
    // catch (Exception ex)
    // {
    //     var logger = services.GetRequiredService<ILogger<Program>>();
    //     logger.LogError(ex, "An error occurred while seeding the DB.");
    // }
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapHub<ChatHub>("/chatHub");

app.Run();

public partial class Program { }