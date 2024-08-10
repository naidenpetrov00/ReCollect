namespace Domain.UnitTests
{
    using PackIT.Domain.Events;
    using PackIT.Domain.Factory;
    using PackIT.Domain.Policies;
    using PackIT.Domain.Exceptions;

    using Xunit;
    using FluentAssertions;
    using PackIT.Domain.ValueObjects.PackingItems;
    using PackIT.Domain.ValueObjects.PackingLists;
    using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;

    public class PackingListTests
	{
		[Fact]
		public void AddItem_Throws_PackingItemExistsException_WhenItemWithSameNameExists()
		{
			var packingList = this.GetPackingList();
			packingList.AddItem(new PackingItem { Name = "Item 1", Quantity = 1 });

			var exception = Record.Exception(() => packingList.AddItem(new PackingItem { Name = "Item 1", Quantity = 1 }));

			exception.Should().NotBeNull();
			exception.Should().BeOfType<PackingItemExistsException>();
		}

		[Fact]
		public void AddItem_Adds_PackingItemAdded_DomainEvent_OnSuccess()
		{
			var packingList = this.GetPackingList();

			var exception = Record.Exception(() => packingList.AddItem(new PackingItem { Name = "Item 1", Quantity = 1 }));

			exception.Should().BeNull();
			packingList.Events.Count.Should().Be(1);

			var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;
			@event.Should().NotBeNull();
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
