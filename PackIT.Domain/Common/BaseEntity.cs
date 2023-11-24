namespace PackIT.Domain.Common
{
	public abstract class BaseEntity<T>
	{
		private bool _versionIncremented;
		private readonly List<IDomainEvent> _events = new();

		public T Id { get; protected set; }
		public int Version { get; protected set; }
		public IReadOnlyCollection<IDomainEvent> Events => _events;


		protected void AddEvent(IDomainEvent @event)
		{
			if (!this._events.Any() && !_versionIncremented)
			{
				this.Version++;
				this._versionIncremented = true;

				this._events.Add(@event);
			}
		}

		public void ClearEvents()
			=> this._events.Clear();


		protected void Increment()
		{
			if (_versionIncremented)
			{
				return;
			}

			Version++;
			_versionIncremented = true;
		}
	}
}
