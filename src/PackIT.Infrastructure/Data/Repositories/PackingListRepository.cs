namespace PackIT.Infrastructure.Data.Repositories;

using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using PackIT.Domain.AggregatesModel.PackingAggregate;
using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;

internal sealed class PackingListRepository : IPackingListReository
{
    private readonly ApplicationDbContext dbContext;

    public PackingListRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<PackingList> GetAsync(int id)
    {
        var packingList = await this.dbContext.PackingLists.FindAsync(id);
        Guard.Against.Null(packingList);
        return packingList;
    }

    public void Add(PackingList packingList) => dbContext.PackingLists.Add(packingList);

    public void Delete(PackingList packingList) => this.dbContext.PackingLists.Remove(packingList);

    public void Update(PackingList packingList) => this.dbContext.PackingLists.Update(packingList);
}
