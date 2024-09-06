using Carter;
using Gorkem_.Context;
using Gorkem_.Pipeline;
using Gorkem_.ServiceCollection;
using Gorkem_.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

string ConnectionString = builder.Configuration.GetConnectionString("GorkemAppConnection")??string.Empty;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();
builder.Services.RegisterApiServiceCollection(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();   

var app = builder.Build();



AutoMigrate.ApplyMigration(app);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); 
app.UseExceptionHandler();
app.MapCarter();
app.Run();


