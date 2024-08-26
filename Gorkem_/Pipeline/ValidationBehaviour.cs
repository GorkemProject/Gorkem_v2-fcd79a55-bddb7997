using AspNetCoreHero.Results;
using FluentValidation;
using MediatR;

namespace Gorkem_.Pipeline
{
    public sealed class ValidationBehavior<TRequest, TResponse>
: IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>
 where TResponse : Result
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(
                _validators.Select(validator => validator.ValidateAsync(context)));

            var errors = _validators
                     .Select(x => x.Validate(context))
                     .SelectMany(x => x.Errors)
                     .GroupBy(r => r.ErrorMessage)
                     .Select(r => r.FirstOrDefault())
                     .Where(x => x != null).ToList();

            if (errors.Any())
            {
                throw new ValidationException(string.Join("--", errors.Select(r => r.ErrorMessage)));
            }

            var response = await next();

            return response;
        }
    }
}
