namespace ReCollect.Infrastructure;

using System.Reflection;
using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReCollect.Application.SeedWork.Interfaces;
using ReCollect.Domain.AggregatesModel.PackingAggregate;
using ReCollect.Infrastructure.Data;
using ReCollect.Infrastructure.Data.Options;
using ReCollect.Infrastructure.Data.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );

#if(UseDocker)
        var mssqlConnectionString = configuration
            .GetOptions<MssqlOptions>("MSSQL")
            .ConnectionStringDockerCompose;
        Guard.Against.Null(
            mssqlConnectionString,
            message: "Connection String for docker composed not found!"
        );
#else
        var mssqlConnectionString = configuration
            .GetOptions<MssqlOptions>("MSSQL")
            .ConnectionStringDotNetBuildWithDockerDb;
        Guard.Against.Null(
            mssqlConnectionString,
            message: "Connection String for docker db only not found!"
        );
#endif

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(mssqlConnectionString)
        );
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>()
        );
        services.AddScoped<ApplicationDbContextInitialiser>();
        services.AddScoped<IPackingListRepository, PackingListRepository>();

        return services;
    }
}
