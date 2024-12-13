using ContactList.Bll.Models.Contact;
using FluentValidation;

namespace ContactList.Bll.Validators.Contact;

public class UpdateContactModelValidator : AbstractValidator<UpdateContactModel>
{
    public UpdateContactModelValidator()
    {
        RuleFor(request => request.Id)
            .Must(x => x > 0)
            .WithMessage("Id must be positive.");
        RuleFor(request => request.Name)
            .NotEmpty()
            .WithMessage("Name must be not empty.");
        RuleFor(request => request.PhoneNumber)
            .NotEmpty()
            .WithMessage("PhoneNumber must be not empty.");
        RuleFor(request => request.PersonId)
            .Must(x => x > 0)
            .WithMessage("PersonId must be positive.");
    }
}