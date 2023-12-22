namespace PackIT.Domain.Policies
{
	using PackIT.Domain.ValueObjects;
	using PackIT.Domain.ValueObjects.PackingLists;

	public record PolicyData(TravelDays Days, Enums.Gender Gender, ValueObjects.Temperature Temperature, Localization Localization) { }
}
