namespace ReCollect.Server;

using ReCollect.Application;
using ReCollect.Infrastructure;
using ReCollect.Infrastructure.SeedWork;
using ReCollect.Server.Infrastructure;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            await app.InitializeDatabaseAsync();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapEndpoints();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapFallbackToFile("/index.html");

        app.Run();
    }
}
