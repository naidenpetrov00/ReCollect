namespace PackIT.Application.PackingList.Commands.AddPackingItem;

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PackIT.Application.Common.Interfaces;

public class AddPackingItemCommandValidator : AbstractValidator<AddPackingItemCommand>
{
    private readonly IApplicationDbContext dbContext;

    public AddPackingItemCommandValidator(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;

        RuleFor(pl => pl.PackingListId)
            .NotEmpty()
            .MustAsync(PackingListShouldExist)
            .WithMessage("{PropertyName} must exist");
    }

    public async Task<bool> PackingListShouldExist(
        int packingListId,
        CancellationToken cancellationToken
    ) =>
        await this.dbContext.PackingLists.AnyAsync(pl => pl.Id == packingListId, cancellationToken);
}
