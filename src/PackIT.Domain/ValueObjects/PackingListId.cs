namespace PackIT.Domain.ValueObjects
{
	using PackIT.Domain.Exceptions;

	public record PackingListId
	{
		public Guid Value { get; }

		public PackingListId(Guid value)
		{
			if (value == Guid.Empty)
			{
				throw new EmptyPackingListIdException();
			}

			this.Value = value;
		}

		public static implicit operator PackingListId(Guid id)
			=> new (id);
		public static implicit operator Guid(PackingListId id)
			=> id.Value;
	}
}
