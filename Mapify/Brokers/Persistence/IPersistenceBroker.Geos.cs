using Mapify.Models;

namespace GeoApi.Brokers.Storage;

public partial interface IPersistenceBroker
{
    IQueryable<GeoLookup> SelectAllGeos();
}
