using ValidationException = FluentValidation.ValidationException;

namespace FSE.API.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(val => val.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(results => results.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    _logger.LogWarning("Validation errors - {CommandType} - Command: {@Command} - Errors: {@ValidationErrors}", request.GetType().Name, request, failures);

                    throw new ProfileDomainException(
                        $"Command Validation Errors for type {typeof(TRequest).Name}", new ValidationException("Validation exception", failures));
                }
            }

            return await next();
        }
    }
}
