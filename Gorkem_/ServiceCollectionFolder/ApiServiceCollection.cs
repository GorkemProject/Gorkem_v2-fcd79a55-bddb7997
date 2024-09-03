using Gorkem_.Context;
using Gorkem_.Pipeline;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation;
namespace Gorkem_.ServiceCollection
{
    public static class ApiServiceCollection
    {
        public static void RegisterApiServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));

            services.AddDbContext<GorkemDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("GorkemAppConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("GorkemAppConnection")), options =>
                {
                    options.UseMicrosoftJson();
                });
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
        }
    }
}
