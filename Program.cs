using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using donuts.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the database connection dynamically
string? connectionString;

try
{
    // Try to get RDS connection details from environment variables
    var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
    var dbUsername = Environment.GetEnvironmentVariable("DB_USERNAME");
    var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
    
    if (!string.IsNullOrEmpty(dbHost) && !string.IsNullOrEmpty(dbUsername) && !string.IsNullOrEmpty(dbPassword))
    {
        connectionString = $"Server={dbHost};Database=donutdb;User Id={dbUsername};Password={dbPassword};";
        builder.Services.AddDbContext<DonutDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        Console.WriteLine("Using RDS database connection.");
    }
    else
    {
        throw new Exception("RDS connection details are missing.");
    }
}
catch
{
    // Fall back to SQLite if RDS connection fails or environment variables are not set
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<DonutDbContext>(options =>
    {
        options.UseSqlite(connectionString);
    });

    Console.WriteLine("Using SQLite fallback database connection.");
}

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
