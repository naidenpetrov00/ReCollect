namespace ReCollect.Domain.Exceptions;

public class EmptyPackingListItemNameException : Exception
{
    public EmptyPackingListItemNameException()
        : base("Packing item name cannot be empty.") { }
}
