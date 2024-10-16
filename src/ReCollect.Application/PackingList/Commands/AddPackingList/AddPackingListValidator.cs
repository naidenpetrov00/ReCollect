namespace ReCollect.Application.PackingList.Commands.AddPackingList;

using FluentValidation;

public class AddPackingListValidator : AbstractValidator<AddPackingList>
{
    public AddPackingListValidator()
    {
        RuleFor(pl => pl.Name).NotEmpty();
    }
}
