namespace ReCollect.Application.PackingList;

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReCollect.Domain.Events;

public class PackingItemAddedEventHandler : INotificationHandler<PackingItemAdded>
{
    public Task Handle(PackingItemAdded notification, CancellationToken cancellationToken)
    {
        //Logic for event handling
        throw new NotImplementedException();
    }
}
