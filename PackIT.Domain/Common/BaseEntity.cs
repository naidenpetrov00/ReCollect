namespace PackIT.Domain.Common
{
	public abstract class BaseEntity<T>
	{
		private readonly List<IDomainEvent> events = new ();
		private bool versionIncremented;

		public T Id { get; protected set; }

		public int Version { get; protected set; }

		public IReadOnlyCollection<IDomainEvent> Events => this.events;

		public void ClearEvents()
			=> this.events.Clear();

		protected void AddEvent(IDomainEvent @event)
		{
			if (!this.events.Any() && !this.versionIncremented)
			{
				this.Version++;
				this.versionIncremented = true;

				this.events.Add(@event);
			}
		}

		protected void Increment()
		{
			if (this.versionIncremented)
			{
				return;
			}

			this.Version++;
			this.versionIncremented = true;
		}
	}
}
