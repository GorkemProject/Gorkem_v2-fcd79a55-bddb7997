using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.User;
using Gorkem_.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Auth
{
    public static class Login
    {
        public record LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public record Command(LoginRequest Request) : IRequest<Result<UserResponse>>;

        internal sealed record Handler(GorkemDbContext Context, JwtService JwtService) : IRequestHandler<Command, Result<UserResponse>>
        {
            public async Task<Result<UserResponse>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await Context.Users
                    .FirstOrDefaultAsync(u => u.Username == request.Request.Username && u.Password == request.Request.Password);

                if (user == null)
                    return await Result<UserResponse>.FailAsync("Kullanıcı adı veya şifre hatalı");

                if (!user.IsActive)
                    return await Result<UserResponse>.FailAsync("Hesabınız aktif değil");

                var token = JwtService.GenerateToken(user);
                var userResponse = new UserResponse
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    Role = user.Role,
                    IsActive = user.IsActive,
                    Token = token
                };
                return await Result<UserResponse>.SuccessAsync(userResponse, "Giriş başarılı");
            }
        }
    }

    public class LoginEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("auth/login", async ([FromBody] Login.LoginRequest model, ISender sender) =>
            {
                var request = new Login.Command(model);
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            })
            .AllowAnonymous()
            .WithTags("Auth");
        }
    }
} 