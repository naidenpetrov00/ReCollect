namespace PackIT.Application.Common.Interfaces
{
    using Microsoft.EntityFrameworkCore;
    using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;

    public interface IApplicationDbContext
	{
		DbSet<PackingList> PackingLists { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
