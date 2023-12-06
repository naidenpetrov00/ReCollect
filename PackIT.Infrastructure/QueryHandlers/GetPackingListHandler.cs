namespace PackIT.Infrastructure.QueryHandlers
{
	using PackIT.Infrastructure.EF.Models;
	using PackIT.Infrastructure.EF.Contexts;
	using PackIT.Application.PackingList.Queries;
	using PackIT.Application.DTO;

	using Microsoft.EntityFrameworkCore;
	using MediatR;

	internal class GetPackingListHandler : IRequestHandler<GetPackingList, PackingListDto>
	{
		private readonly DbSet<PackingListReadModel> packingLists;

		public GetPackingListHandler(ReadDbContext context)
		{
			this.packingLists = context.PackingLists;
		}

		public async Task<PackingListDto> Handle(GetPackingList request, CancellationToken cancellationToken)
			=> await this.packingLists
					.Where(pl => pl.Id == request.Id)
					.Select(pl => new PackingListDto
					{
						Id = pl.Id,
						Name = pl.Name,
						LocalizationDto = new LocalizationDto
						{
							City = pl.Localization.City,
							Country = pl.Localization.Country,
						},
						Items = pl.Items.Select(pi => new PackingItemDto
						{
							Name = pi.Name,
							Quantity = pi.Quantity,
							IsPacked = pi.IsPacked,
						})
					})
					.AsNoTracking()
					.SingleOrDefaultAsync();
	}
}
