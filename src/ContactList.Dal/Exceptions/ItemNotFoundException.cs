namespace ContactList.Dal.Exceptions;

public class ItemNotFoundException : ArgumentException
{
    public ItemNotFoundException(string itemName, object itemId) : base(
        $"Item {itemName} with ID '{itemId}' was not found.")
    {
    }
}