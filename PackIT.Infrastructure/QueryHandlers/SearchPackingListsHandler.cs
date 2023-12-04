namespace PackIT.Infrastructure.QueryHandlers
{
	using PackIT.Application.PackingList.Queries;

	using MediatR;
	using PackIT.Infrastructure.EF.Models;

	public class SearchPackingListsHandler : IRequestHandler<SearchPackingLists, IEnumerable<PackingListReadModel>>
	{
		private readonly PackItDbContext;

		public async Task<IEnumerable<PackingListReadModel>> Handle(SearchPackingLists request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
