namespace Domain.UnitTests
{
	using PackIT.Domain.Entities;
	using PackIT.Domain.Factory;
	using PackIT.Domain.Policies;
	using PackIT.Domain.ValueObjects;
	using Xunit;

	public class PackingListTests
	{
		[Fact]
		public void AddItem_Throws_PackingItemExistsException_WhenItemWithSameNameExists()
		{

		}

		private readonly IPackingListFactory factory;

		public PackingListTests()
		{
			this.factory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolicy>());
		}

		private PackingList GetPackingList()
		{
			var packingList = this.factory.CreatePackingList(Guid.NewGuid(), "MyTestList", Localization.Create("Sofia, Bulgaria"));
			packingList.ClearEvents();
			return packingList;
		}
	}
}
