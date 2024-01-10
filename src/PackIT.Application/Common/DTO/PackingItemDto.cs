namespace PackIT.Application.Common.DTO
{
	using PackIT.Domain.ValueObjects.PackingItems;

	using AutoMapper;
	using PackIT.Application.Common.Mapping;

	public class PackingItemDto : IMapFrom<PackingItem>
	{
		public string Name { get; set; }
		public uint Quantity { get; set; }
		public bool IsPacked { get; set; }
	}
}
