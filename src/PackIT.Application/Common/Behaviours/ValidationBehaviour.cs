namespace PackIT.Application.Common.Behaviours
{
	using FluentValidation;
	using MediatR;
	using System.Threading;
	using System.Threading.Tasks;

	public class ValidationBehaviour<TRequest, TRespose> : IPipelineBehavior<TRequest, TRespose>
		where TRequest : notnull
	{
		private readonly IEnumerable<IValidator<TRequest>> validators;

		public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
		{
			this.validators = validators;
		}

		public async Task<TRespose> Handle(TRequest request, RequestHandlerDelegate<TRespose> next, CancellationToken cancellationToken)
		{
			if (this.validators.Any())
			{
				var context = new ValidationContext<TRequest>(request);

				var validationResults = await Task.WhenAll(
					this.validators.Select(validator =>
						validator.ValidateAsync(context, cancellationToken)));

				var errors = validationResults
					.Where(r => r.Errors.Any())
					.SelectMany(r => r.Errors)
					.ToList();

				if (errors.Any())
				{
					throw new ValidationException(errors);
				}
			}

			return await next();
		}
	}
}
