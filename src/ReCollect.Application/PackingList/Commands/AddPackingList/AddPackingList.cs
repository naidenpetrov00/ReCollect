namespace ReCollect.Application.PackingList.Commands.AddPackingList;

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReCollect.Application.SeedWork.Interfaces;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;
using ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

public record AddPackingList(string Name) : IRequest<int>;

public class AddPackingListCommandHandler : IRequestHandler<AddPackingList, int>
{
    private readonly IApplicationDbContext dbContext;

    public AddPackingListCommandHandler(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<int> Handle(AddPackingList request, CancellationToken cancellationToken)
    {
        var packingList = new PackingList { Name = (PackingListName)request.Name };
        dbContext.PackingLists.Add(packingList);

        await this.dbContext.SaveChangesAsync(cancellationToken);

        return packingList.Id;
    }
}
