namespace PackIT.Application.PackingList.Commands.AddPackingItem
{
	using PackIT.Application.Common.Exceptions;

	using PackIT.Domain.Repositories;
	using PackIT.Domain.ValueObjects.PackingItems;

	using System.Threading;
	using MediatR;

	public record AddPackingItem(Guid PackingListId, string Name, uint Quantity) : IRequest;


	internal sealed class AddPackingItemHandler : IRequestHandler<AddPackingItem>
	{
		private readonly IPackingListRepository repository;

		public AddPackingItemHandler(IPackingListRepository repository)
			=> this.repository = repository;

		public async Task Handle(AddPackingItem request, CancellationToken cancellationToken)
		{
			var packingList = await this.repository.GetAsync(request.PackingListId);

			if (packingList is null)
			{
				throw new PackingListNotFoundException(request.PackingListId);
			}

			var packingItem = new PackingItem
			{
				Name = request.Name,
				Quantity = request.Quantity,
			};
			packingList.AddItem(packingItem);

			await this.repository.UpdateAsync(packingList);
		}
	}
}
