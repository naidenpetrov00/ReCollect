namespace PackIT.Application
{
    using PackIT.Domain.Factory;
    using PackIT.Domain.Policies;

    using PackIT.Application.Common.Behaviours;

    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using MediatR;
    using FluentValidation;
    using PackIT.Application.SeedWork.Behaviours;

    public static class DependencyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			var assembly = Assembly.GetCallingAssembly();

			services.AddSingleton<IPackingListFactory, PackingListFactory>();
			services.AddLogging();

			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
				cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
				cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
			});

			services.Scan(selector => selector.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
				.AddClasses(c => c.AssignableTo(typeof(IPackingItemsPolicy)))
				.AsImplementedInterfaces()
				.WithSingletonLifetime());

			return services;
		}
	}
}
