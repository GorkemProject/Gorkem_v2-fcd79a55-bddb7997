using Carter;
using Gorkem_.Context;
using Gorkem_.Pipeline;
using Gorkem_.ServiceCollection;
using Gorkem_.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using System.Security.Claims;
var builder = WebApplication.CreateBuilder(args);

string ConnectionString = builder.Configuration.GetConnectionString("GorkemAppConnection")??string.Empty;

#region SeriLog Start


builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var loggerFactory = LoggerFactory.Create(builder =>{
    builder.AddConsole(); // Logları konsola yazdır
});

var logger = loggerFactory.CreateLogger<Program>();
logger.LogInformation("Docker log test mesajı");


#endregion


builder.Services.AddCors(options =>
{
    options.AddPolicy("GorkemCORS", policy =>
    {
        policy.WithOrigins("https://gorkem","https://10.203.8.145", "http://localhost:3000", "https://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();
builder.Services.RegisterApiServiceCollection(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.Authority = "https://narkoauth.polnet.intra"; // IdentityServer URL
           options.Audience = "narkonet.resource"; // Ensure this matches the API resource name
           options.RequireHttpsMetadata = false;
           options.IncludeErrorDetails = true;
           options.TokenValidationParameters = new TokenValidationParameters
           {
               NameClaimType = ClaimTypes.Name,
               RoleClaimType = ClaimTypes.Role,
               ValidateIssuer = false,
               ValidateAudience = false,
               ValidateIssuerSigningKey = false,
               IssuerSigningKeyResolver = (token, securityToken, identifier, validationParameters) =>
               {
                   var client = new HttpClient();
                   var response = client.GetStringAsync("https://narkoauth.polnet.intra/.well-known/openid-configuration/jwks").Result;
                   var keys = new JsonWebKeySet(response);
                   return keys.GetSigningKeys();
               }


           };
       });

    builder.Services.AddAuthorizationBuilder()
      .AddPolicy("ApiScope", policy =>policy.RequireAuthenticatedUser());




var app = builder.Build();



AutoMigrate.ApplyMigration(app);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseCors("GorkemCORS");
app.UseExceptionHandler();

app.MapCarter();
  app.UseAuthentication();
    app.UseAuthorization();

app.Run();


