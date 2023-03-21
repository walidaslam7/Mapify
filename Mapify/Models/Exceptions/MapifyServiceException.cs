namespace Mapify.Models.Exceptions;

public class MapifyServiceException : Exception
{
    public MapifyServiceException(Exception innerException)
       : base("Service exception occurred, contact support", innerException)
    {
    }
}