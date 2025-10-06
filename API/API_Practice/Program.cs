
using API_Practice.src.database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DatabaseContext>(option => option.UseInMemoryDatabase("database"));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(Options =>
    {
        Options.DocumentPath = "/openapi/v1.json";//path to test data file update once created
    });
}

