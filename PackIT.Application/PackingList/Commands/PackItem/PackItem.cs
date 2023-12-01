namespace PackIT.Application.PackingList.Commands.PackItem
{
	using PackIT.Application.Exceptions;
	using PackIT.Domain.Repositories;

	using System.Threading;
	using MediatR;

	public record PackItem(Guid PackingListId, string Name) : IRequest;

	internal sealed class PackItemHandler : IRequestHandler<PackItem>
	{
		private readonly IPackingListRepository _repository;

		public PackItemHandler(IPackingListRepository repository)
			=> _repository = repository;

		public async Task Handle(PackItem request, CancellationToken cancellationToken)
		{
			var packingList = await _repository.GetAsync(request.PackingListId);

			if (packingList is null)
			{
				throw new PackingListNotFoundException(request.PackingListId);
			}

			packingList.PackItem(request.Name);

			await _repository.UpdateAsync(packingList);
		}
	}
}
