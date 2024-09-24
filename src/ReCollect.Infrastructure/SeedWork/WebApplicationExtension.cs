namespace ReCollect.Infrastructure.SeedWork;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ReCollect.Infrastructure.Data;

public static class WebApplicationExtension
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initializer =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initializer.InitalizeDatabaseAsync();
    }
}
