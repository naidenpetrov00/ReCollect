namespace PackIT.Application.PackingList.Commands.RemovePackingItem
{
	using PackIT.Application.Common.Exceptions;

	using PackIT.Domain.Repositories;

	using MediatR;

	public record RemovePackingItem(Guid PackingListId, string Name) : IRequest;

	internal sealed class RemovePackingItemHandler : IRequestHandler<RemovePackingItem>
	{
		private readonly IPackingListRepository repository;

		public RemovePackingItemHandler(IPackingListRepository repository)
			=> this.repository = repository;

		public async Task Handle(RemovePackingItem request, CancellationToken cancellationToken)
		{
			var packingList = await this.repository.GetAsync(request.PackingListId);

			if (packingList is null)
			{
				throw new PackingListNotFoundException(request.PackingListId);
			}

			packingList.UnpackItem(request.Name);

			await this.repository.UpdateAsync(packingList);
		}
	}
}
