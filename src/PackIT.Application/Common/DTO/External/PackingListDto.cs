namespace PackIT.Application.Common.DTO.External
{
	using PackIT.Application.Common.DTO;

	using PackIT.Domain.Entities;

	using AutoMapper;

	public class PackingListDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public LocalizationDto LocalizationDto { get; set; }

		public IEnumerable<PackingItemDto> Items { get; set; }

		private class Mapping : Profile
		{
			public Mapping()
			{
				CreateMap<PackingList, PackingListDto>();
			}
		}
	}
}
