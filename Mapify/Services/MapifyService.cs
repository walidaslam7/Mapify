using GeoApi.Brokers.Storage;
using Mapify.Brokers.Logging;
using Mapify.Models;

namespace Mapify.Services;

public partial class MapifyService : IMapifyService
{
    private readonly IPersistenceBroker _presistenceBroker;
    private readonly ILoggingBroker _loggingBroker;

    public MapifyService(IPersistenceBroker presistenceBroker, ILoggingBroker loggingBroker)
    {
        _presistenceBroker = presistenceBroker;
        _loggingBroker = loggingBroker;
    }

    public IQueryable<GeoLookup> RetrieveAllGeos() => TryCatch(() =>
    {
        IQueryable<GeoLookup> presistenceGeos = _presistenceBroker.SelectAllGeos();
        ValidatePersistenceGeos(presistenceGeos);

        return presistenceGeos;
    });
}