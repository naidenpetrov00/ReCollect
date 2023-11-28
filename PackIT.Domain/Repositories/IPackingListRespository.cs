namespace PackIT.Domain.Repositories
{
	using PackIT.Domain.Entities;
	using PackIT.Domain.ValueObjects;

	public interface IPackingListRespository
	{
		Task<PackingList> GetAsync(PackingListId id);

		Task<PackingList> AddAsync(PackingListId id);

		Task<PackingList> UpdateAsync(PackingListId id);

		Task<PackingList> DeleteAsync(PackingListId id);
	}
}
