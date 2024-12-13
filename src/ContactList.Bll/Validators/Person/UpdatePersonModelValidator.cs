using ContactList.Bll.Models.Person;
using FluentValidation;

namespace ContactList.Bll.Validators.Person;

public class UpdatePersonModelValidator : AbstractValidator<UpdatePersonModel>
{
    public UpdatePersonModelValidator()
    {
        RuleFor(request => request.Id)
            .Must(x => x > 0)
            .WithMessage("Id must be positive.");
        RuleFor(request => request.FirstName)
            .NotEmpty()
            .WithMessage("FirstName must be not empty.");
        RuleFor(request => request.LastName)
            .NotEmpty()
            .WithMessage("LastName must be not empty.");
    }
}