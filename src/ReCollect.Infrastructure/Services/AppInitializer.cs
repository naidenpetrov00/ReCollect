namespace ReCollect.Infrastructure.Services;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal sealed class AppInitializer : IHostedService
{
    private readonly IServiceProvider serviceProvider;

    public AppInitializer(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var dbContextTypes = AppDomain
            .CurrentDomain.GetAssemblies()
            .SelectMany(t => t.GetTypes())
            .Where(a =>
                typeof(DbContext).IsAssignableFrom(a) && !a.IsInterface && a != typeof(DbContext)
            );

        using var scope = this.serviceProvider.CreateScope();
        foreach (var dbType in dbContextTypes)
        {
            var dbContext = scope.ServiceProvider.GetRequiredService(dbType) as DbContext;
            if (dbContext == null)
            {
                continue;
            }

            await dbContext.Database.MigrateAsync(cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
