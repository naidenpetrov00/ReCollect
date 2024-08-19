namespace PackIT.Application.Common.DTO
{
	using PackIT.Domain.ValueObjects.PackingItems;

	using AutoMapper;

	public class PackingItemDto
	{
		public string Name { get; init; }
		public uint Quantity { get; init; }
		public bool IsPacked { get; init; }

		public class Mapping : Profile
		{
			public Mapping()
			{
				CreateMap<PackingItem, PackingItemDto>();
			}
		}
	}
}
