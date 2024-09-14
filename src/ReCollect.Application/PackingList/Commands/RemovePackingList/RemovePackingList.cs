namespace ReCollect.Application.PackingList.Commands.RemovePackingList;

using Ardalis.GuardClauses;
using MediatR;
using ReCollect.Application.Common.Exceptions;
using ReCollect.Domain.AggregatesModel.PackingAggregate;

public record RemovePackingList(int Id) : IRequest;

internal sealed class RemovePackingListHandler : IRequestHandler<RemovePackingList>
{
    private readonly IPackingListRepository repository;

    public RemovePackingListHandler(IPackingListRepository repository) =>
        this.repository = repository;

    public async Task Handle(RemovePackingList request, CancellationToken cancellationToken)
    {
        var packingList = await this.repository.GetAsync(request.Id);

        Guard.Against.NotFound(request.Id, packingList);

        this.repository.Delete(packingList);
    }
}
