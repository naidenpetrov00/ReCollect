namespace PackIT.Infrastructure.Services
{
    using PackIT.Application.Common.DTO;
    using PackIT.Application.Services;

    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using PackIT.Infrastructure.Data.Contexts;

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
