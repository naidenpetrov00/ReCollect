namespace PackIT.Application.PackingList.Queries.GetPackingList
{
	using PackIT.Application.Common.Interfaces;

	using FluentValidation;
	using Microsoft.EntityFrameworkCore;
	using System;

	public class GetPackingListValidator : AbstractValidator<GetPackingList>
	{
		private readonly IApplicationDbContext context;

		public GetPackingListValidator(IApplicationDbContext context)
		{
			this.context = context;

			RuleFor(pl => pl.Id)
				.NotEmpty()
				.MustAsync(PackingListMustExist)
				.WithMessage("Packing list with id: '{PropertyValue}' must exist")
				.WithErrorCode("Not Existing");
		}

		private async Task<bool> PackingListMustExist(Guid packingListId, CancellationToken cancellationToken)
		{
			return await this.context.PackingLists
				.AnyAsync(pl => (Guid)pl.Id == packingListId);
		}
	}
}
