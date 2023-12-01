namespace PackIT.Application.PackingList.Commands.RemovePackingList
{
	using PackIT.Application.Exceptions;
	using PackIT.Domain.Repositories;

	using MediatR;

	public record RemovePackingList(Guid Id) : IRequest;

	internal sealed class RemovePackingListHandler : IRequestHandler<RemovePackingList>
	{
		private readonly IPackingListRepository _repository;

		public RemovePackingListHandler(IPackingListRepository repository)
			=> _repository = repository;

		public async Task Handle(RemovePackingList request, CancellationToken cancellationToken)
		{
			var packingList = await _repository.GetAsync(request.Id);

			if (packingList is null)
			{
				throw new PackingListNotFoundException(request.Id);
			}

			await _repository.DeleteAsync(packingList);
		}
	}
}
