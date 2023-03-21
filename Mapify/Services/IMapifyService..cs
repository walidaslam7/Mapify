using Mapify.Models;

namespace Mapify.Services;

public interface IMapifyService
{
    IQueryable<GeoLookup> RetrieveAllGeos();
}
