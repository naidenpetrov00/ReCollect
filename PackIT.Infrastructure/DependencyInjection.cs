namespace PackIT.Infrastructure
{
	using PackIT.Infrastructure.EF.Options;
	using PackIT.Infrastructure.EF.Contexts;
	using PackIT.Infrastructure.EF.Repositories;
	using PackIT.Infrastructure.Services;
	using PackIT.Application.Services;
	using PackIT.Domain.Repositories;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IWeatherService, DummyWeatherService>();

			services.AddScoped<IPackingListRepository, PostgresPackingListRepository>();
			services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();

			services.AddHostedService<AppInitializer>();

			var postgresOptions = configuration.GetOptions<PostgresOptions>("Postgres");
			services.AddDbContext<ReadDbContext>(ctx => ctx.UseNpgsql(postgresOptions.ConnectionString));
			services.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(postgresOptions.ConnectionString));

			return services;
		}
	}
}
