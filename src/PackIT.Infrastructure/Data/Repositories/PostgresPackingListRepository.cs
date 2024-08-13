namespace PackIT.Infrastructure.EF.Repositories
{
    using PackIT.Domain.Repositories;

    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using PackIT.Domain.ValueObjects.PackingLists;
    using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;
    using PackIT.Infrastructure.Data.Contexts;

    internal sealed class PostgresPackingListRepository : IPackingListRepository
	{
		private readonly DbSet<PackingList> packingLists;
		private readonly WriteDbContext writeDbContext;

		public PostgresPackingListRepository(WriteDbContext writeDbContext)
		{
			this.packingLists = writeDbContext.PackingLists;
			this.writeDbContext = writeDbContext;
		}

		public async Task AddAsync(PackingList packingList)
		{
			await this.packingLists.AddAsync(packingList);
			await this.writeDbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(PackingList packingList)
		{
			this.packingLists.Remove(packingList);
			await this.writeDbContext.SaveChangesAsync();
		}

		public async Task<PackingList> GetAsync(PackingListId id)
		{
			return await this.packingLists
			   .Where(pl => pl.Id == id)
			   .AsNoTracking()
			   .FirstOrDefaultAsync();
		}

		public async Task UpdateAsync(PackingList packingList)
		{
			this.packingLists.Update(packingList);
			await this.writeDbContext.SaveChangesAsync();
		}
	}
}
