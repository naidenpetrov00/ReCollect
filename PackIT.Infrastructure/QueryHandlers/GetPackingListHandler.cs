namespace PackIT.Infrastructure.QueryHandlers
{
	using PackIT.Application.PackingList.Queries;
	using PackIT.Domain.Repositories;

	using MediatR;
	using PackIT.Infrastructure.EF.Models;

	public class GetPackingListHandler : IRequestHandler<GetPackingList, PackingListReadModel>
	{
		private readonly IPackingListRepository repository;

		public GetPackingListHandler(IPackingListRepository repository)
		{
			this.repository = repository;
		}

		public async Task<PackingListReadModel> Handle(GetPackingList request, CancellationToken cancellationToken)
		{
			var packingList = await this.repository.GetAsync(request.Id);

			return packingList?.AsDto();
		}
	}
}
