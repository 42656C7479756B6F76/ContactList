using ContactList.Dal.Models.Contact;
using ContactList.Dal.Models.Person;
using ContactList.Domain;

namespace ContactList.Dal.Repositories.Interfaces;

public interface IContactRepository
{
    Task<long[]> Add(ContactEntityV1[] contacts, CancellationToken token);

    Task<ContactEntityV1[]> GetPersonContacts(PersonGetContactsModel query, CancellationToken token);

    Task<ContactEntityV1> Update(ContactUpdateModel query, CancellationToken token);

    Task<bool> Delete(ContactDeleteModel query, CancellationToken token);
}