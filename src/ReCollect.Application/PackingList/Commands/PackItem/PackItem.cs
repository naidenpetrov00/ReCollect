namespace ReCollect.Application.PackingList.Commands.PackItem;

using System.Threading;
using Ardalis.GuardClauses;
using MediatR;
using ReCollect.Application.Common.Exceptions;
using ReCollect.Domain.AggregatesModel.PackingAggregate;

public record PackItem(int PackingListId, string Name) : IRequest;

internal sealed class PackItemHandler : IRequestHandler<PackItem>
{
    private readonly IPackingListRepository repository;

    public PackItemHandler(IPackingListRepository repository) => this.repository = repository;

    public async Task Handle(PackItem request, CancellationToken cancellationToken)
    {
        var packingList = await this.repository.GetAsync(request.PackingListId);

        Guard.Against.NotFound(request.PackingListId, packingList);

        packingList.PackItem(request.Name);

        this.repository.Update(packingList);
    }
}
