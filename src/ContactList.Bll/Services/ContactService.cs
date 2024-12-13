using ContactList.Bll.Models.Contact;
using ContactList.Bll.Services.Interfaces;
using ContactList.Dal.Models.Contact;
using ContactList.Dal.Models.Person;
using ContactList.Dal.Repositories.Interfaces;
using ContactList.Domain;

namespace ContactList.Bll.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<long> Add(AddContactModel model, CancellationToken token)
    {
        return (await _contactRepository.Add([
                    new ContactEntityV1
                    {
                        Name = model.Name,
                        PhoneNumber = model.PhoneNumber,
                        PersonId = model.PersonId,
                        CreatedAt = DateTimeOffset.UtcNow
                    }
                ], token
            ))
            .First();
    }

    public async Task<GetContactModel[]> GetPersonContacts(GetPersonContactsModel model, CancellationToken token)
    {
        return
            (await _contactRepository.GetPersonContacts(
                new PersonGetContactsModel
                {
                    PersonId = model.PersonId
                }, token))
            .Select(x => new GetContactModel
            {
                Id = x.Id,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                CreatedAt = x.CreatedAt
            })
            .ToArray();
    }

    public async Task<GetContactModel> Update(UpdateContactModel model, CancellationToken token)
    {
        var contactEntity = await _contactRepository.Update(new ContactUpdateModel
        {
            Id = model.Id,
            Name = model.Name,
            PhoneNumber = model.PhoneNumber,
            PersonId = model.PersonId
        }, token);

        return new GetContactModel
        {
            Id = contactEntity.Id,
            Name = contactEntity.Name,
            PhoneNumber = contactEntity.PhoneNumber,
            CreatedAt = contactEntity.CreatedAt
        };
    }

    public async Task<bool> Delete(DeleteContactModel model, CancellationToken token)
    {
        return await _contactRepository.Delete(new ContactDeleteModel
        {
            ContactId = model.ContactId
        }, token);
    }
}