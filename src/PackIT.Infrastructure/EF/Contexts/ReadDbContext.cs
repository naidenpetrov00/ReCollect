namespace PackIT.Infrastructure.EF.Contexts
{
	using PackIT.Infrastructure.EF.Configurations;

	using Microsoft.EntityFrameworkCore;
	using PackIT.Application.Common.DTO;

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
			modelBuilder.ApplyConfiguration<PackingItemReadModel>(configuration);
			modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);

			base.OnModelCreating(modelBuilder);
		}
	}
}
