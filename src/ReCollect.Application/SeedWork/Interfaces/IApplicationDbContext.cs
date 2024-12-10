namespace ReCollect.Application.SeedWork.Interfaces;

using Microsoft.EntityFrameworkCore;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

public interface IApplicationDbContext
{
    DbSet<PackingList> PackingLists { get; }

    DbSet<PackingItem> PackingItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
