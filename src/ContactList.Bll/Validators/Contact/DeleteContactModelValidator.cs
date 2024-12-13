using ContactList.Bll.Models.Contact;
using FluentValidation;

namespace ContactList.Bll.Validators.Contact;

public class DeleteContactModelValidator : AbstractValidator<DeleteContactModel>
{
    public DeleteContactModelValidator()
    {
        RuleFor(request => request.ContactId)
            .Must(x => x > 0)
            .WithMessage("ContactId must be positive.");
    }
}