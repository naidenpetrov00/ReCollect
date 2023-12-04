namespace PackIT.Infrastructure.EF.Contexts
{
	using PackIT.Infrastructure.EF.Models;

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
			base.OnModelCreating(modelBuilder);
		}
	}
}
