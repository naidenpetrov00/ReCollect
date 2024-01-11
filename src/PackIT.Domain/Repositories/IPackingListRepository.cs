namespace PackIT.Domain.Repositories
{
    using PackIT.Domain.Entities;
    using PackIT.Domain.ValueObjects.PackingLists;

    public interface IPackingListRepository
	{
		Task<PackingList> GetAsync(PackingListId id);

		Task AddAsync(PackingList packingList);

		Task UpdateAsync(PackingList packingList);

		Task DeleteAsync(PackingList packingList);
	}
}
