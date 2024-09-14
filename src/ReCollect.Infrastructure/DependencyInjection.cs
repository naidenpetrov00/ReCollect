namespace ReCollect.Infrastructure;

using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReCollect.Application.Common.Interfaces;
using ReCollect.Application.Services;
using ReCollect.Domain.AggregatesModel.PackingAggregate;
using ReCollect.Infrastructure.Data;
using ReCollect.Infrastructure.Data.Repositories;
using ReCollect.Infrastructure.EF.Options;
using ReCollect.Infrastructure.Logging;
using ReCollect.Infrastructure.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddSingleton<IWeatherService, DummyWeatherService>();

        services.AddScoped<IPackingListRepository, PackingListRepository>();
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

        services.TryDecorate(typeof(IRequestHandler<>), typeof(LoggingCommandHandlerDecorator<>));

        return services;
    }
}
