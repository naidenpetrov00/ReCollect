namespace PackIT.Application.PackingList.Queries.SearchPackingLists
{
	using FluentValidation;

	public class SearchPackingListsValidator : AbstractValidator<SearchPackingLists>
	{
		public SearchPackingListsValidator()
		{
			RuleFor(s => s.SearchPhrase)
				.NotNull();
		}
	}
}
