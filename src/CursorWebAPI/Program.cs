using CursorWebAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("AppDb")
        ?? throw new InvalidOperationException("Missing connection string: ConnectionStrings:AppDb");
    options.UseSqlite(connectionString);
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/health", () => Results.Ok("Healthy"));

app.Run();

public partial class Program { }
