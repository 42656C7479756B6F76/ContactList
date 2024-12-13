using ContactList.Bll.Models.Contact;
using FluentValidation;

namespace ContactList.Bll.Validators.Contact;

public class AddContactModelValidator : AbstractValidator<AddContactModel>
{
    public AddContactModelValidator()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .WithMessage("Name must be not empty.");
        RuleFor(request => request.PhoneNumber)
            .NotEmpty()
            .WithMessage("PhoneNumber must be not empty.");
        RuleFor(request => request.PersonId)
            .Must(x => x >= 0)
            .WithMessage("PersonId must be positive.");
    }
}