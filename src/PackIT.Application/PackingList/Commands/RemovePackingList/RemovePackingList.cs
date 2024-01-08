namespace PackIT.Application.PackingList.Commands.RemovePackingList
{
	using PackIT.Application.Common.Exceptions;

	using PackIT.Domain.Repositories;

	using MediatR;
	using Ardalis.GuardClauses;

	public record RemovePackingList(Guid Id) : IRequest;

	internal sealed class RemovePackingListHandler : IRequestHandler<RemovePackingList>
	{
		private readonly IPackingListRepository repository;

		public RemovePackingListHandler(IPackingListRepository repository)
			=> this.repository = repository;

		public async Task Handle(RemovePackingList request, CancellationToken cancellationToken)
		{
			var packingList = await this.repository.GetAsync(request.Id);

			Guard.Against.NotFound(request.Id, packingList);

			await this.repository.DeleteAsync(packingList);
		}
	}
}
