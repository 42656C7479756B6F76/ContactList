using ContactList.Bll.Models.Contact;
using FluentValidation;

namespace ContactList.Bll.Validators.Contact;

public class GetPersonContactsModelValidator : AbstractValidator<GetPersonContactsModel>
{
    public GetPersonContactsModelValidator()
    {
        RuleFor(request => request.PersonId)
            .Must(x => x > 0)
            .WithMessage("PersonId must be positive.");
    }
}