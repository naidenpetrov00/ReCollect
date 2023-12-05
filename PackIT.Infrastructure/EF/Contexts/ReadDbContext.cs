namespace PackIT.Infrastructure.EF.Contexts
{
	using PackIT.Domain.Entities;

	using Microsoft.EntityFrameworkCore;
	using System.Reflection;

	internal sealed class ReadDbContext : DbContext
	{
		public DbSet<PackingList> PackingLists { get; set; }

		public ReadDbContext(DbContextOptions<ReadDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("packing");
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(modelBuilder);
		}
	}
}
