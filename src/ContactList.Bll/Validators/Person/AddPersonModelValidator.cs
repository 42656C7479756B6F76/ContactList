using ContactList.Bll.Models.Person;
using FluentValidation;

namespace ContactList.Bll.Validators.Person;

public class AddPersonModelValidator : AbstractValidator<AddPersonModel>
{
    public AddPersonModelValidator()
    {
        RuleFor(request => request.FirstName)
            .NotEmpty()
            .WithMessage("FirstName must be not empty.");
        RuleFor(request => request.LastName)
            .NotEmpty()
            .WithMessage("LastName must be not empty.");
    }
}