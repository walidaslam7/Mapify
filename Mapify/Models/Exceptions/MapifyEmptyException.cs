namespace Mapify.Models.Exceptions;

public class MapifyEmptyException : Exception
{
    public MapifyEmptyException()
        : base("Empty error occurred, contact support.")
    {
    }
}
