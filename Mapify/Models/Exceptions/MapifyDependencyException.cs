namespace Mapify.Models.Exceptions;

public class MapifyDependencyException : Exception
{
    public MapifyDependencyException(Exception innerException)
        : base("Service dependency exception occurred, contact support", innerException)
    {
    }
}
