using BacPeBune.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.DataProtection;
using System.IO;                          
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
using System.Data.Common;
using MySqlConnector;  


=======
=======
>>>>>>> Stashed changes
using Microsoft.AspNetCore.DataProtection; 
using System.IO;
using Microsoft.Extensions.Logging;      
using BacPeBune.Models;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

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

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

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
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
        //await SeedData.Initialize(services); 
=======
        context.Database.Migrate();
=======
        context.Database.Migrate();
>>>>>>> Stashed changes
        if (!context.Lessons.Any())
        {
            context.Lessons.Add(
            new Lesson
            {
                LessonID = 1,
                Title = "Introduction to Programming",
                Lector = 1,
                SubjectID = "Informatica",
                PdfLink = "https://google.com"
            }
        );
        }
        
        context.SaveChanges();
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the DB.");
    }

    
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();