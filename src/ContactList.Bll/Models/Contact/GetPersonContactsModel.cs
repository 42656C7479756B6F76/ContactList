namespace ContactList.Bll.Models.Contact;

public record GetPersonContactsModel
{
    public required long PersonId { get; init; }
}