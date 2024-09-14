namespace ReCollect.Domain.AggregatesModel.PackingAggregate;

using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;
using ReCollect.Domain.SeedWork;

public interface IPackingListRepository : IRepository<PackingList>
{
    Task<PackingList> GetAsync(int id);

    void Add(PackingList packingList);

    void Update(PackingList packingList);

    void Delete(PackingList packingList);
}
