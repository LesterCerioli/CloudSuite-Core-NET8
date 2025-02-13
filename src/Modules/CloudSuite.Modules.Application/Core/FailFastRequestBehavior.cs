using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CloudSuite.Modules.Application.Core
{
	public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse> where TResponse : Response
	{
		private readonly IEnumerable<IValidator> _validators;

		public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
		{
			var response = new Response();

			foreach (var failure in failures)
			{
				response.AddError(failure.ErrorMessage);
			}

			return Task.FromResult(response as TResponse);
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var failures = _validators
				.Select(v => v.Validate((IValidationContext)request))
				.SelectMany(result => result.Errors)
				.Where(f => f != null)
				.ToList();

			return await (failures.Any()
				? Errors(failures)
				: next());
		}
	}
}