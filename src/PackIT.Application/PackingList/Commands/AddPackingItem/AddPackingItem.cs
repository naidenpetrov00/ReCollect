namespace PackIT.Application.PackingList.Commands.AddPackingItem
{
	using PackIT.Domain.Repositories;
	using PackIT.Domain.ValueObjects.PackingItems;

	using System.Threading;
	using MediatR;
	using Ardalis.GuardClauses;
	using PackIT.Application.Common.Interfaces;

	public record AddPackingItem(Guid PackingListId, string Name, uint Quantity) : IRequest;


	internal sealed class AddPackingItemHandler : IRequestHandler<AddPackingItem>
	{
		private readonly IApplicationDbContext dbContext;

		public AddPackingItemHandler(IApplicationDbContext dbContext)
			=> this.dbContext = dbContext;

		public async Task Handle(AddPackingItem request, CancellationToken cancellationToken)
		{
			var packingList = this.dbContext
				.PackingLists
				.Where(pl => (Guid)pl.Id == request.PackingListId)
				.FirstOrDefault();

			Guard.Against.NotFound(request.PackingListId, packingList);

			var packingItem = new PackingItem
			{
				Name = request.Name,
				Quantity = request.Quantity,
			};
			packingList.AddItem(packingItem);

			await this.dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
