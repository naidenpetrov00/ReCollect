namespace PackIT.Infrastructure
{
    using System.Reflection;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PackIT.Application.Common.Interfaces;
    using PackIT.Application.Services;
    using PackIT.Domain.AggregatesModel.PackingAggregate;
    using PackIT.Infrastructure.Data;
    using PackIT.Infrastructure.Data.Repositories;
    using PackIT.Infrastructure.EF.Options;
    using PackIT.Infrastructure.Logging;
    using PackIT.Infrastructure.Services;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddSingleton<IWeatherService, DummyWeatherService>();

            services.AddScoped<IPackingListReository, PackingListRepository>();
            services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();
            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetRequiredService<ApplicationDbContext>()
            );
			
            services.AddHostedService<AppInitializer>();

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            var postgresOptions = configuration.GetOptions<PostgresOptions>("Postgres");
            services.AddDbContext<ApplicationDbContext>(ctx =>
                ctx.UseNpgsql(postgresOptions.ConnectionString)
            );

            services.TryDecorate(
                typeof(IRequestHandler<>),
                typeof(LoggingCommandHandlerDecorator<>)
            );

            return services;
        }
    }
}
