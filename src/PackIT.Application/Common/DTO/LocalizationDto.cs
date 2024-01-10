namespace PackIT.Application.Common.DTO
{
	using AutoMapper;

	using PackIT.Domain.ValueObjects.PackingLists;

	public class LocalizationDto
	{
		public string City { get; set; }

		public string Country { get; set; }

		public class Mapping : Profile
		{
			public Mapping()
			{
				CreateMap<Localization, LocalizationDto>();
			}
		}
	}
}
