namespace PackIT.Application.PackingList.Queries
{
	using PackIT.Application.DTO;

	using MediatR;

	public class GetPackingList : IRequest<PackingListDto>
	{
		public Guid Id { get; set; }
	}
}
