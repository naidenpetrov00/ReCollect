namespace PackIT.Application.Common.Interfaces
{
	using PackIT.Domain.Entities;

	using Microsoft.EntityFrameworkCore;
	public interface IApplicationDbContext
	{
		DbSet<PackingList> PackingLists { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
