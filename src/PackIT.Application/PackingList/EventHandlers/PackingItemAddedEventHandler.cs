namespace PackIT.Application.PackingList;

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PackIT.Domain.Events;

public class PackingItemAddedEventHandler : INotificationHandler<PackingItemAdded>
{
    public Task Handle(PackingItemAdded notification, CancellationToken cancellationToken)
    {
        //Logic for event handling
        throw new NotImplementedException();
    }
}
