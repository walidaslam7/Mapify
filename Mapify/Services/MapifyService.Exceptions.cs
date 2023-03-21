using Mapify.Models;
using Mapify.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Mapify.Services;

public partial class MapifyService
{
    private delegate IQueryable<GeoLookup> ReturningGeosFunction();

    private IQueryable<GeoLookup> TryCatch(ReturningGeosFunction returningGeosFunction)
    {
        try
        {
            return returningGeosFunction();
        }
        catch (SqlException sqlException)
        {
            throw CreateAndLogCriticalDependencyException(sqlException);
        }
        catch (DbUpdateException dbUpdateException)
        {
            throw CreateAndLogDependencyException(dbUpdateException);
        }
        catch (MapifyEmptyException emptyGeosException)
        {
            throw CreateAndLogCriticalDependencyException(emptyGeosException);
        }
        catch (Exception serviceException)
        {
            throw CreateAndLogServiceException(serviceException);
        }
    }

    private MapifyDependencyException CreateAndLogCriticalDependencyException(Exception exception)
    {
        var geoDependencyException = new MapifyDependencyException(exception);
        _loggingBroker.LogCritical(geoDependencyException);

        return geoDependencyException;
    }

    private MapifyDependencyException CreateAndLogDependencyException(Exception exception)
    {
        var geoDependencyException = new MapifyDependencyException(exception);
        _loggingBroker.LogError(geoDependencyException);

        return geoDependencyException;
    }

    private MapifyServiceException CreateAndLogServiceException(Exception exception)
    {
        var geoServiceException = new MapifyServiceException(exception);
        _loggingBroker.LogError(geoServiceException);

        return geoServiceException;
    }
}
