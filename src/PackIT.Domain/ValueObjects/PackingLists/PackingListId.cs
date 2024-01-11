namespace PackIT.Domain.ValueObjects.PackingLists
{
	using Ardalis.GuardClauses;
	using PackIT.Domain.Exceptions;

	public record PackingListId
	{
		public Guid Value { get; }

		public PackingListId(Guid value)
		{
			Guard.Against.NullOrEmpty(value, "Packing list ID cannot be empty");

			Value = value;
		}

		public static implicit operator PackingListId(Guid value)
			=> new PackingListId(value);
		public static implicit operator Guid(PackingListId id)
			=> id.Value;
	}
}
