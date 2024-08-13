namespace PackIT.Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;
using PackIT.Application.Common.DTO;

public interface IApplicationReadDbContext
{
    DbSet<PackingListReadModel> PackingLists { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
