namespace PackIT.Infrastructure.EF.Contexts
{
	using PackIT.Infrastructure.EF.Models;
	using PackIT.Infrastructure.EF.Configurations;
	using PackIT.Domain.Entities;
	using PackIT.Domain.ValueObjects;

	using Microsoft.EntityFrameworkCore;

	internal sealed class WriteDbContext : DbContext
	{
		public DbSet<PackingListReadModel> PackingLists { get; set; }

		public WriteDbContext()
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("packing");

			var configuration = new WriteConfiguration();
			modelBuilder.ApplyConfiguration<PackingList>(configuration);
			modelBuilder.ApplyConfiguration<PackingItem>(configuration);

			base.OnModelCreating(modelBuilder);
		}
	}
}
