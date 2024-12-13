namespace ContactList.Bll.Models.Contact;

public record DeleteContactModel
{
    public required long ContactId { get; init; }
}