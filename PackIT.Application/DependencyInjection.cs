namespace PackIT.Application
{
	using PackIT.Domain.Factory;
	using PackIT.Domain.Policies;
	using PackIT.Application.Commands;
	using PackIT.Application.Common.Intefaces;

	using System.Reflection;
	using Microsoft.Extensions.DependencyInjection;

	public static class DependencyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			var assembly = Assembly.GetCallingAssembly();

			services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
			services.Scan(selector => selector.FromAssemblies(assembly)
				.AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
				.AsImplementedInterfaces()
				.WithScopedLifetime());

			services.AddSingleton<IPackingListFactory, PackingListFactory>();

			services.Scan(selector => selector.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
				.AddClasses(c => c.AssignableTo(typeof(IPackingItemsPolicy)))
				.AsImplementedInterfaces()
				.WithSingletonLifetime());

			return services;
		}
	}
}
