namespace PackIT.Domain.Policies
{
	using PackIT.Domain.Enums;
	using PackIT.Domain.ValueObjects;

	public record PolicyData(TravelDays Days, Enums.Gender Gender, ValueObjects.Temperature Temperature, Localization Localization) { }
}
