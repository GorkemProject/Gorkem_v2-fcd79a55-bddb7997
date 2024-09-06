using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Pipeline
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly  Serilog.ILogger  _logger;

        public GlobalExceptionHandler(Serilog.ILogger  logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.Fatal("Hata Açıklaması: {0}", exception);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Server error",
                Detail=exception.Message
            };

         

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

    }
}
