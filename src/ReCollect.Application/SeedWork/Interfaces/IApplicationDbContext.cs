namespace ReCollect.Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

public interface IApplicationDbContext
{
    DbSet<PackingList> PackingLists { get; set; }

    DbSet<PackingItem> PackingItems { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
