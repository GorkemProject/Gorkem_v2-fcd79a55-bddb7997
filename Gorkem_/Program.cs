using Carter;
using Gorkem_.Context;
using Gorkem_.Pipeline;
using Gorkem_.ServiceCollection;
using Gorkem_.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

string ConnectionString = builder.Configuration.GetConnectionString("GorkemAppConnection")??string.Empty;



#region SeriLog Start


builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

 
#endregion


builder.Services.AddCors(options =>
{
    options.AddPolicy("GorkemCORS", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


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

app.UseCors("GorkemCORS");
app.UseSerilogRequestLogging();
app.UseHttpsRedirection(); 
app.UseExceptionHandler();
app.MapCarter();

app.Run();


