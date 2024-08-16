namespace PackIT.Domain.AggregatesModel.PackingAggregate;

using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;
using PackIT.Domain.SeedWork;

public interface IPackingListReository : IRepository<PackingList>
{
    Task<PackingList> GetAsync(int id);

    void Add(PackingList packingList);

    void Update(PackingList packingList);

    void Delete(PackingList packingList);
}
