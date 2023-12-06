namespace PackIT.Infrastructure.QueryHandlers
{
	using PackIT.Infrastructure.EF.Models;
	using PackIT.Infrastructure.EF.Contexts;
	using PackIT.Application.DTO;
	using PackIT.Application.PackingList.Queries;

	using Microsoft.EntityFrameworkCore;
	using MediatR;

	internal sealed class SearchPackingListsHandler : IRequestHandler<SearchPackingLists, IEnumerable<PackingListDto>>
	{
		private readonly DbSet<PackingListReadModel> packingLists;

		public SearchPackingListsHandler(ReadDbContext context)
		{
			this.packingLists = context.PackingLists;
		}

		public async Task<IEnumerable<PackingListDto>> Handle(SearchPackingLists request, CancellationToken cancellationToken)
		{
			var dbQuery = this.packingLists.Include(x => x.Items).AsQueryable();

			if (request.SearchPhrase is not null)
			{
				// Warning (Ef may not be able to convert)
				dbQuery = dbQuery.Where(pl => pl.Name.Contains(request.SearchPhrase, StringComparison.OrdinalIgnoreCase));
			}

			return await dbQuery
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
				.ToListAsync();
		}
	}
}
