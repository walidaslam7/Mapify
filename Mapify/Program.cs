using GeoApi.Brokers.Storage;
using Mapify.Extensions;
using Mapify.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enabling fluent configuration with many different features of OData
builder.Services.AddControllers().AddOData(opt => opt.EnableQueryFeatures().AddRouteComponents("odata", GetEdmModel()));

builder.Services.ConfigureLoggers();
builder.Services.ConfigureService();
InitializeStorage(builder.Services, configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<GeoLookup>("Geos");
    return builder.GetEdmModel();
}

void InitializeStorage(IServiceCollection services, ConfigurationManager configuration)
{
    string connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    services.AddDbContext<PersistenceBroker>(options => options.UseSqlServer(connectionString));
    services.AddTransient<IPersistenceBroker, PersistenceBroker>();
}