using ContactList.Bll.Models.Person;
using ContactList.Bll.Services.Interfaces;
using ContactList.Dal.Models.Person;
using ContactList.Dal.Repositories.Interfaces;
using ContactList.Domain;

namespace ContactList.Bll.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<long> Add(AddPersonModel model, CancellationToken token)
    {
        var personEntity = new PersonEntityV1
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            CreatedAt = DateTimeOffset.UtcNow
        };

        var id = (await _personRepository.Add([personEntity], token))
            .First();

        return id;
    }

    public async Task<GetPersonModel> Get(GetPersonByIdModel model, CancellationToken token)
    {
        var personEntity = await _personRepository.Get(
            new PersonGetModel
            {
                PersonId = model.Id
            },
            token);

        return new GetPersonModel
        {
            Id = personEntity.Id,
            FirstName = personEntity.FirstName,
            LastName = personEntity.LastName
        };
    }

    public async Task<GetPersonModel> Update(UpdatePersonModel model, CancellationToken token)
    {
        var personEntity = await _personRepository.Update(new PersonUpdateModel
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName
        }, token);

        return new GetPersonModel
        {
            Id = personEntity.Id,
            FirstName = personEntity.FirstName,
            LastName = personEntity.LastName
        };
    }

    public async Task<bool> Delete(DeletePersonModel model, CancellationToken token)
    {
        return await _personRepository.Delete(new PersonDeleteModel
        {
            Id = model.Id
        }, token);
    }
}