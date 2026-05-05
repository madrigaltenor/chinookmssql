using chinookmssqlapi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ChinookContext>(opt =>
    opt.UseSqlServer(Environment.GetEnvironmentVariable("CHINOOKCONNECTIONSTRING"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/ping", () => new { Message = "Running"});

app.MapGet("/artists", (ChinookContext ctx) =>
{
    return ctx.Artists.ToList();
});

app.Run();

