namespace PackIT.Application.Common.DTO
{
	using PackIT.Application.Common.Mapping;

	using PackIT.Domain.ValueObjects.PackingLists;

	public class LocalizationDto : IMapFrom<Localization>
	{
		public string City { get; set; }

		public string Country { get; set; }
	}
}
