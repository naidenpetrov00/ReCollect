namespace PackIT.Application.PackingList.Queries
{
	using PackIT.Application.DTO;

	using MediatR;

	public class SearchPackingLists : IRequest<IEnumerable<PackingListDto>>
	{
		public string SearchPhrase { get; set; }
	}
}
