namespace PackIT.Infrastructure.EF.Contexts
{
	using PackIT.Infrastructure.EF.Config;
	using PackIT.Infrastructure.EF.Models;

	using Microsoft.EntityFrameworkCore;

	internal sealed class ReadDbContext : DbContext
	{
		public DbSet<PackingListReadModel> PackingLists { get; set; }

		public ReadDbContext(DbContextOptions<ReadDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("packing");
			var configuration = new ReadConfiguration();
			modelBuilder.ApplyConfiguration(configuration);

			base.OnModelCreating(modelBuilder);
		}
	}
}
