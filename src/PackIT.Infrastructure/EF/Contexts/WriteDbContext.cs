namespace PackIT.Infrastructure.EF.Contexts
{
    using PackIT.Infrastructure.EF.Configurations;
    using PackIT.Domain.ValueObjects.PackingItems;

    using Microsoft.EntityFrameworkCore;
    using PackIT.Application.Common.Interfaces;
    using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;

    internal sealed class WriteDbContext : DbContext , IApplicationDbContext
	{
		public DbSet<PackingList> PackingLists { get; set; }

		public WriteDbContext(DbContextOptions<WriteDbContext> options)
			: base(options)
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
