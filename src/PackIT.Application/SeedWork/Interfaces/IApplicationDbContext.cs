namespace PackIT.Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;
using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;
using PackIT.Domain.ValueObjects.PackingItems;

public interface IApplicationDbContext
{
    DbSet<PackingList> PackingLists { get; set; }

    DbSet<PackingItem> PackingItems { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
