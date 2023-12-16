namespace PackIT.Infrastructure.Services
{
	using PackIT.Infrastructure.EF.Contexts;
	using PackIT.Infrastructure.EF.Models;
	using PackIT.Application.Services;

	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;

	internal sealed class PostgresPackingListReadService : IPackingListReadService
	{
		private readonly DbSet<PackingListReadModel> packingList;

		public PostgresPackingListReadService(ReadDbContext context)
		{
			this.packingList = context.PackingLists;
		}

		public async Task<bool> ExistsByNameAsync(string name)
			=> await packingList.AnyAsync(x => x.Name == name);
	}
}
