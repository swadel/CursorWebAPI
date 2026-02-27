using CursorWebAPI.Application;
using CursorWebAPI.Endpoints;
using CursorWebAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

builder.Services.AddScoped<IShowRepository, ShowRepository>();
builder.Services.AddScoped<ThisDayService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("AppDb")
        ?? throw new InvalidOperationException("Missing connection string: ConnectionStrings:AppDb");
    options.UseSqlite(connectionString);
});

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/health", () => Results.Ok("Healthy"));
app.MapThisDayEndpoints();

app.Run();

public partial class Program { }
