namespace PackIT.Application.PackingList.Commands.AddPackingItem;

using System.Threading;
using Ardalis.GuardClauses;
using MediatR;
using PackIT.Application.Common.Interfaces;
using PackIT.Domain.ValueObjects.PackingItems;

public record AddPackingItem(int Id, string Name, uint Quantity) : IRequest;

internal sealed class AddPackingItemHandler : IRequestHandler<AddPackingItem>
{
    private readonly IApplicationDbContext dbContext;

    public AddPackingItemHandler(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Handle(AddPackingItem request, CancellationToken cancellationToken)
    {
        var packingList = this
            .dbContext.PackingLists.Where(pl => pl.Id == request.PackingListId)
            .FirstOrDefault();

        Guard.Against.NotFound(request.PackingListId, packingList);

        var packingItem = new PackingItem { Name = request.Name, Quantity = request.Quantity };
        packingList.AddItem(packingItem);

        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
