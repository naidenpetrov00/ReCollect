namespace PackIT.Application.PackingList.Queries.GetPackingList
{
	using PackIT.Domain.Entities;

	using PackIT.Application.Common.Interfaces;
	using PackIT.Application.Common.DTO.External;

	using MediatR;
	using System.Threading;
	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;
	using AutoMapper;
	using AutoMapper.QueryableExtensions;

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
		//.Select(pl => new PackingListDto
		//{
		//	Id = pl.Id,
		//	Name = pl.Name,
		//	LocalizationDto = new LocalizationDto
		//	{
		//		City = pl.Localization.City,
		//		Country = pl.Localization.Country,
		//	},
		//	Items = pl.Items.Select(pi => new PackingItemDto
		//	{
		//		Name = pi.Name,
		//		Quantity = pi.Quantity,
		//		IsPacked = pi.IsPacked,
		//	})
		//})
		//.AsNoTracking()
		//.SingleOrDefaultAsync();
	}
}
