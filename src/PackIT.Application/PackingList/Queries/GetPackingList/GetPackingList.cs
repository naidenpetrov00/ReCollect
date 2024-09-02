namespace PackIT.Application.PackingList.Queries.GetPackingList;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackIT.Application.Common.DTO;
using PackIT.Application.Common.Interfaces;
using PackIT.Application.SeedWork.Security;
using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;

[Authorize]
public record GetPackingList(int Id) : IRequest<PackingListDto>;

public class GetPackingListHandler : IRequestHandler<GetPackingList, PackingListDto>
{
    private readonly DbSet<PackingList> packingLists;
    private readonly IMapper mapper;

    public GetPackingListHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        packingLists = dbContext.PackingLists;
        this.mapper = mapper;
    }

    public async Task<PackingListDto> Handle(
        GetPackingList request,
        CancellationToken cancellationToken
    )
    {
        var packingList = await this
            .packingLists.Where(pl => pl.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<PackingListDto>(this.mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        return packingList!;
    }
}
