using ContactList.Bll.Models.Person;
using FluentValidation;

namespace ContactList.Bll.Validators.Person;

public class DeletePersonModelValidator : AbstractValidator<DeletePersonModel>
{
    public DeletePersonModelValidator()
    {
        RuleFor(request => request.Id)
            .Must(x => x > 0)
            .WithMessage("Id must be positive.");
    }
}