using ContactList.Bll.Models.Contact;
using ContactList.Bll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class ContactController(IContactService contactService) : Controller
{
    [HttpPost]
    [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<long> Add(AddContactModel model, CancellationToken token)
    {
        return await contactService.Add(model, token);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetContactModel[]), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<GetContactModel[]> GetPersonContacts([FromQuery]GetPersonContactsModel model, CancellationToken token)
    {
        return await contactService.GetPersonContacts(model, token);
    }

    [HttpPut]
    [ProducesResponseType(typeof(GetContactModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<GetContactModel> Update(UpdateContactModel model, CancellationToken token)
    {
        return await contactService.Update(model, token);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<bool> Delete(DeleteContactModel model, CancellationToken token)
    {
        return await contactService.Delete(model, token);
    }
}