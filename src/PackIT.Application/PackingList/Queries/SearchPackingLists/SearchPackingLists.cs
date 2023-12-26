namespace PackIT.Application.PackingList.Queries.SearchPackingLists
{
    using MediatR;
    using PackIT.Application.Common.DTO.External;

    public class SearchPackingLists : IRequest<IEnumerable<PackingListDto>>
    {
        public string SearchPhrase { get; set; }
    }
}
