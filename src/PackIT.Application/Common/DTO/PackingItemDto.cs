namespace PackIT.Application.Common.DTO
{
	using PackIT.Domain.ValueObjects.PackingItems;

	using AutoMapper;

	public class PackingItemDto
	{
		public string Name { get; set; }
		public uint Quantity { get; set; }
		public bool IsPacked { get; set; }

		private class Mapping : Profile
		{
			public Mapping()
			{
				CreateMap<PackingItem, PackingItemDto>();
			}
		}
	}
}
