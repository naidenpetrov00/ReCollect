namespace PackIT.Application.PackingList.Commands.RemovePackingItem
{
	using PackIT.Application.Exceptions;
	using PackIT.Domain.Repositories;

	using MediatR;

	public record RemovePackingItem(Guid PackingListId, string Name) : IRequest;

	internal sealed class RemovePackingItemHandler : IRequestHandler<RemovePackingItem>
	{
		private readonly IPackingListRepository _repository;

		public RemovePackingItemHandler(IPackingListRepository repository)
			=> _repository = repository;

		public async Task Handle(RemovePackingItem request, CancellationToken cancellationToken)
		{
			var packingList = await _repository.GetAsync(request.PackingListId);

			if (packingList is null)
			{
				throw new PackingListNotFoundException(request.PackingListId);
			}

			packingList.UnpackItem(request.Name);

			await _repository.UpdateAsync(packingList);
		}
	}
}
