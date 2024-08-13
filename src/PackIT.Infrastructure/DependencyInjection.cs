namespace PackIT.Infrastructure
{
    using PackIT.Domain.Repositories;

    using PackIT.Application.Services;
    using PackIT.Application.Common.Interfaces;

    using PackIT.Infrastructure.EF.Options;
    using PackIT.Infrastructure.EF.Repositories;
    using PackIT.Infrastructure.Services;
    using PackIT.Infrastructure.Logging;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MediatR;
    using System.Reflection;
    using PackIT.Infrastructure.Data.Contexts;

    public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IWeatherService, DummyWeatherService>();

			services.AddScoped<IPackingListRepository, PostgresPackingListRepository>();
			services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();

			services.AddHostedService<AppInitializer>();

			services.AddMediatR(cfg => 
				cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			var postgresOptions = configuration.GetOptions<PostgresOptions>("Postgres");
			services.AddDbContext<ReadDbContext>(ctx => ctx.UseNpgsql(postgresOptions.ConnectionString));
			services.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(postgresOptions.ConnectionString));

			services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<WriteDbContext>());

			services.TryDecorate(typeof(IRequestHandler<>), typeof(LoggingCommandHandlerDecorator<>));

			return services;
		}
	}
}
