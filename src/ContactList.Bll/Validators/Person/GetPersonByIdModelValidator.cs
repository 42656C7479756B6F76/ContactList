using ContactList.Bll.Models.Person;
using FluentValidation;

namespace ContactList.Bll.Validators.Person;

public class GetPersonByIdModelValidator : AbstractValidator<GetPersonByIdModel>
{
    public GetPersonByIdModelValidator()
    {
        RuleFor(request => request.Id)
            .Must(x => x > 0)
            .WithMessage("Id must be positive.");
    }
}