using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VisualReader.Application.Models.Errors;

namespace VisualReader.Application.Pipelines
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IServiceProvider _serviceProvider;

        public RequestValidationBehavior(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Initialize validation context.
            var context = new ValidationContext<TRequest>(request);

            // Get the instance to be validated.
            var instance = context.InstanceToValidate;
            if (instance == null)
                return await next();

            // Pre-defined validation is available.
            // Do the local validation first.
            var validators = _serviceProvider.GetServices<IValidator<TRequest>>();
            if (validators.Any())
            {
                foreach (var validator in validators)
                {
                    var validationResult = await validator.ValidateAsync(request, cancellationToken);
                    if (validationResult == null)
                        continue;

                    if (!validationResult.IsValid)
                        throw new EntityValidationException(validationResult.Errors.Select(x => new FluentValidation.Results.ValidationFailure(x.PropertyName, x.ErrorMessage)).ToList());
                }
            }

            return await next();
        }
    }
}