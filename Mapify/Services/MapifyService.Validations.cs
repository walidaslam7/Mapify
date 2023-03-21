using Mapify.Models;
using Mapify.Models.Exceptions;

namespace Mapify.Services;

public partial class MapifyService
{
    private void ValidatePersistenceGeos(IQueryable<GeoLookup> storageGeos)
    {
        if (storageGeos.Count() == 0) throw new MapifyEmptyException();
    }
}
