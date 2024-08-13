namespace PackIT.Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;
using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;

public interface IApplicationWriteDbContext
{
    DbSet<PackingList> PackingLists { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
