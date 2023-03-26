using Mapify.Models;
using Mapify.Models.Exceptions;
using Mapify.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Mapify.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GeosController : ControllerBase
{
    private readonly IMapifyService _mapifyService;
    public GeosController(IMapifyService mapifyService) => _mapifyService = mapifyService;
    /// <summary>
    /// Returns Cities Geo Information as per PageSize.
    /// </summary>
    /// <returns>Retrieve All Geos</returns>
    /// <response code="200">Returns the Geo codes as Per request</response>
    /// <response code="500">If the request failed</response>
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IQueryable<GeoLookup>> Get()
    {
        try
        {
            return Ok(_mapifyService.RetrieveAllGeos());
        }
        catch (MapifyDependencyException geoDependencyException)
        {
            return Problem(geoDependencyException.Message);
        }
        catch (MapifyServiceException geoServiceException)
        {
            return Problem(geoServiceException.Message);
        }
    }
}
