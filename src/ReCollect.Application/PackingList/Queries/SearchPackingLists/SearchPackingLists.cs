namespace ReCollect.Application.PackingList.Queries.SearchPackingLists;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ReCollect.Application.PackingList.Queries.GetPackingList;
using ReCollect.Application.SeedWork.Interfaces;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

public class SearchPackingLists : IRequest<IEnumerable<PackingListDto>>
{
    public string SearchPhrase { get; set; }
}

public class SearchPackingListsHandler
    : IRequestHandler<SearchPackingLists, IEnumerable<PackingListDto>>
{
    private readonly DbSet<PackingList> packingLists;
    private readonly IMapper mapper;

    public SearchPackingListsHandler(IApplicationDbContext context, IMapper mapper)
    {
        this.packingLists = context.PackingLists;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<PackingListDto>> Handle(
        SearchPackingLists request,
        CancellationToken cancellationToken
    )
    {
        var searchQuery = this.packingLists.AsQueryable();

        if (request.SearchPhrase is not null)
        {
            // Warning (Ef may not be able to convert)
            searchQuery = searchQuery.Where(pl =>
                EF.Functions.Like(pl.Name, $"%{request.SearchPhrase}%")
            );
        }

        return await searchQuery
            .Select(pl => this.mapper.Map<PackingListDto>(pl))
            .AsNoTracking()
            .ToListAsync();
    }
}
