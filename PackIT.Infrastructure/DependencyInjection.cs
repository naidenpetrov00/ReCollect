namespace PackIT.Infrastructure
{
	using PackIT.Infrastructure.EF.Options;
	using PackIT.Infrastructure.EF.Contexts;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			var postgresOptions = configuration.GetOptions<PostgresOptions>("Postgres");
			services.AddDbContext<ReadDbContext>(ctx => ctx.UseNpgsql(postgresOptions.ConnectionString));
			services.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(postgresOptions.ConnectionString));

			return services;
		}
	}
}
