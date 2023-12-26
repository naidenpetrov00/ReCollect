namespace PackIT.Application.PackingList.Commands.PackItem
{
	using PackIT.Application.Common.Exceptions;

	using PackIT.Domain.Repositories;

	using System.Threading;
	using MediatR;

	public record PackItem(Guid PackingListId, string Name) : IRequest;

	internal sealed class PackItemHandler : IRequestHandler<PackItem>
	{
		private readonly IPackingListRepository repository;

		public PackItemHandler(IPackingListRepository repository)
			=> this.repository = repository;

		public async Task Handle(PackItem request, CancellationToken cancellationToken)
		{
			var packingList = await this.repository.GetAsync(request.PackingListId);

			if (packingList is null)
			{
				throw new PackingListNotFoundException(request.PackingListId);
			}

			packingList.PackItem(request.Name);

			await this.repository.UpdateAsync(packingList);
		}
	}
}
