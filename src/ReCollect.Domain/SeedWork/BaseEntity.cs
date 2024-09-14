namespace ReCollect.Domain.SeedWork;

using System.ComponentModel.DataAnnotations.Schema;

public abstract class BaseEntity
{
#pragma warning disable CS8618
    public int Id { get; private set; }
#pragma warning restore CS8618

    private List<BaseEvent> events = new();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> Events => this.events.AsReadOnly();

    protected void AddDomainEvent(BaseEvent domainEvent)
    {
        this.events ??= new List<BaseEvent>();
        this.events.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseEvent domainEvent) => this.events.Remove(domainEvent);

    public void ClearDomainEvents() => this.events.Clear();
}
