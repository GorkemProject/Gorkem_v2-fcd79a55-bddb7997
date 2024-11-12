using MediatR;
using System.Text.Json;
using System.Text;

namespace Gorkem_.Pipeline
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        private readonly IHttpContextAccessor _contextAccessor;
        public LoggingBehaviour(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            //var authHeader = _contextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            //var username = _contextAccessor.HttpContext.User.Claims.Where(r => r.Type == "preferred_username").First().Value;


            var d = typeof(TRequest);


            var ctxRequest = _contextAccessor.HttpContext.Request;
            var uriBuilder = new UriBuilder
            {
                Scheme = ctxRequest.Scheme,
                Host = ctxRequest.Host.Host,
                Port = ctxRequest.Host.Port ?? (ctxRequest.Scheme == "https" ? 443 : 80),
                Path = ctxRequest.Path.ToString(),
                Query = ctxRequest.QueryString.ToString()
            };

            var pathInfo = ctxRequest.Path.ToString().Split("/");







            return await next();
        }
    }
}
