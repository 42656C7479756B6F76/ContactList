using ContactList.Bll.Models.Contact;

namespace ContactList.Bll.Services.Interfaces;

public interface IContactService
{
    Task<long> Add(AddContactModel model, CancellationToken token);

    Task<GetContactModel[]> GetPersonContacts(GetPersonContactsModel model, CancellationToken token);

    Task<GetContactModel> Update(UpdateContactModel model, CancellationToken token);

    Task<bool> Delete(DeleteContactModel model, CancellationToken token);
}