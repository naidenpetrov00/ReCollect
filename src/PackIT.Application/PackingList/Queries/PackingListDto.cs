namespace PackIT.Application.Common.DTO
{
	using AutoMapper;
	using PackIT.Domain.Entities;

	public class PackingListDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public LocalizationDto LocalizationDto { get; set; }

		public IEnumerable<PackingItemDto> Items { get; set; }

		public class Mapping : Profile
		{
			public Mapping()
			{
				CreateMap<PackingList, PackingListDto>()
					.ForMember(pl => pl.Id, opt => opt.MapFrom(src => (Guid)src.Id));
			}
		}
	}
}
