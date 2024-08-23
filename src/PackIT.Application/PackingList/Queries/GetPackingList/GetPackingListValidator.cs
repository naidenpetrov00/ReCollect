namespace PackIT.Application.PackingList.Queries.GetPackingList;

using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PackIT.Application.Common.Interfaces;

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

    private async Task<bool> PackingListMustExist(
        int packingListId,
        CancellationToken cancellationToken
    ) => await this.context.PackingLists.AnyAsync(pl => pl.Id == packingListId);
}
