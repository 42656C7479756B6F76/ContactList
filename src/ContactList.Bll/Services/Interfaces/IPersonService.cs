using ContactList.Bll.Models.Person;

namespace ContactList.Bll.Services.Interfaces;

public interface IPersonService
{
    Task<long> Add(AddPersonModel model, CancellationToken token);

    Task<GetPersonModel> Get(GetPersonByIdModel model, CancellationToken token);

    Task<GetPersonModel> Update(UpdatePersonModel model, CancellationToken token);

    Task<bool> Delete(DeletePersonModel model, CancellationToken token);
}