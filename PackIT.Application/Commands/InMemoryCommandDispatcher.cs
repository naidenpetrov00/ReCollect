namespace PackIT.Application.Commands
{
	using PackIT.Application.Common.Intefaces;

	using Microsoft.Extensions.DependencyInjection;

	internal class InMemoryCommandDispatcher : ICommandDispatcher
	{
		private readonly IServiceProvider serviceProvider;

		public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
			=> this.serviceProvider = serviceProvider;

		public async Task DispatchAsync<TCommand>(TCommand command)
			where TCommand : class, ICommand
		{
			using var scope = this.serviceProvider.CreateScope();
			var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

			await handler.HandleAsync(command);
		}
	}
}
