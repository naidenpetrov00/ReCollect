namespace PackIT.Application.PackingList.Queries.GetPackingList
{
    using PackIT.Application.Common.DTO;
    using PackIT.Application.Common.Interfaces;

    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;

    public class GetPackingList : IRequest<PackingListDto>
	{
		public Guid Id { get; set; }
	}

	public class GetPackingListHandler : IRequestHandler<GetPackingList, PackingListDto>
	{
		private readonly DbSet<PackingList> packingLists;
		private readonly IMapper mapper;

		public GetPackingListHandler(
			IApplicationDbContext dbContext,
			IMapper mapper)
		{
			packingLists = dbContext.PackingLists;
			this.mapper = mapper;
		}

		public async Task<PackingListDto> Handle(GetPackingList request, CancellationToken cancellationToken)
			=> this.packingLists
					.Where(pl => (Guid)pl.Id == request.Id)
					.ProjectTo<PackingListDto>(mapper.ConfigurationProvider)
					.AsNoTracking()
					.SingleOrDefault();
	}
}
