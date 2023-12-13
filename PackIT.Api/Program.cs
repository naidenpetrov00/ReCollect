namespace PackIT.Api
{
	using Microsoft.Extensions.DependencyInjection;
	using PackIT.Application;
	using PackIT.Application.PackingList.Commands.AddPackingItem;
	using PackIT.Infrastructure;
	using System.Reflection;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("PackIT.Application")));
			builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("PackIT.Infrastructure")));
			builder.Services.AddApplicationServices();
			builder.Services.AddInfrastructureServices(builder.Configuration);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseErrorHandling();
			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
