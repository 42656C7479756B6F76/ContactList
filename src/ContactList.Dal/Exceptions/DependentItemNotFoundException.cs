namespace ContactList.Dal.Exceptions;

public class DependentItemNotFoundException : ArgumentException
{
    public DependentItemNotFoundException(
        string dependentItemName,
        object dependentItemId) :
        base($"Dependent {dependentItemName} with ID '{dependentItemId}' was not found.")
    {
    }
}