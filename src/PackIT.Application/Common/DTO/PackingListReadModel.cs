namespace PackIT.Application.Common.DTO
{
	public class PackingListReadModel
	{
		public Guid Id { get; set; }

		public int Version { get; set; }

		public string Name { get; set; }

		public LocalizationReadModel Localization { get; set; }

		public virtual ICollection<PackingItemReadModel> Items { get; set; }
	}
}
