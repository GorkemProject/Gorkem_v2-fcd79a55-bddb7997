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
                                          options.UseSqlServer(configuration.GetConnectionString("GorkemAppConnection")));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
        }
    }
}
