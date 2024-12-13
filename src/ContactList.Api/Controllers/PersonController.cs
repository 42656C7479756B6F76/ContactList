using ContactList.Bll.Models.Person;
using ContactList.Bll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class PersonController(IPersonService personService) : Controller
{
    [HttpPost]
    [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<long> Add(AddPersonModel model, CancellationToken token)
    {
        return await personService.Add(model, token);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetPersonModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<GetPersonModel> Get([FromQuery]GetPersonByIdModel model, CancellationToken token)
    {
        return await personService.Get(model, token);
    }

    [HttpPut]
    [ProducesResponseType(typeof(GetPersonModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<GetPersonModel> Update(UpdatePersonModel model, CancellationToken token)
    {
        return await personService.Update(model, token);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<bool> Delete(DeletePersonModel model, CancellationToken token)
    {
        return await personService.Delete(model, token);
    }
}