namespace ReCollect.Application.PackingList.Commands.RemovePackingItem;

using Ardalis.GuardClauses;
using MediatR;
using ReCollect.Domain.AggregatesModel.PackingAggregate;

public record RemovePackingItem(int PackingListId, string Name) : IRequest;

internal sealed class RemovePackingItemHandler : IRequestHandler<RemovePackingItem>
{
    private readonly IPackingListRepository repository;

    public RemovePackingItemHandler(IPackingListRepository repository) =>
        this.repository = repository;

    public async Task Handle(RemovePackingItem request, CancellationToken cancellationToken)
    {
        var packingList = await this.repository.GetAsync(request.PackingListId);

        Guard.Against.NotFound(request.PackingListId, packingList);

        packingList.UnpackItem(request.Name);

        this.repository.Update(packingList);
    }
}
