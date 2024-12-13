using ContactList.Dal.Models.Person;
using ContactList.Domain;

namespace ContactList.Dal.Repositories.Interfaces;

public interface IPersonRepository
{
    Task<long[]> Add(PersonEntityV1[] persons, CancellationToken token);

    Task<PersonEntityV1> Get(PersonGetModel query, CancellationToken token);

    Task<PersonEntityV1> Update(PersonUpdateModel query, CancellationToken token);

    Task<bool> Delete(PersonDeleteModel query, CancellationToken token);
}