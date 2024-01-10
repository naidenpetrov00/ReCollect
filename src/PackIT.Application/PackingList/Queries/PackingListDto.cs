namespace PackIT.Application.Common.DTO
{
	using PackIT.Application.Common.Mapping;

	using PackIT.Domain.Entities;

	using AutoMapper;

	public class PackingListDto /*: IMapFrom<PackingList>*/
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
		//public void Mapping(Profile profile)
		//{
		//	profile.CreateMap<PackingList, PackingListDto>()
		//		.ForMember(pl => pl.Id, opt => opt.MapFrom(src => (Guid)src.Id));
		//}
	}
}
