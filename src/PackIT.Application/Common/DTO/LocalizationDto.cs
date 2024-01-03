namespace PackIT.Application.Common.DTO
{
	using PackIT.Domain.ValueObjects.PackingLists;

	using AutoMapper;

	public class LocalizationDto
	{
		public string City { get; set; }

		public string Country { get; set; }

		private class Mapping : Profile
		{
			public Mapping()
			{
				this.CreateMap<Localization, LocalizationDto>();
			}
		}
	}
}
