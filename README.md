 <img align="left" width="130" height="130" src="https://github.com/walidaslam7/Mapify/blob/main/.github/icon.png?raw=true" />
 

# Mapify - Your Guide to Global Coordinates

[![Build and Test](https://github.com/walidaslam7/Mapify/actions/workflows/dotnet-build.yml/badge.svg?branch=main)](https://github.com/walidaslam7/Mapify/actions/workflows/dotnet-build.yml)
[![Super-Linter](https://github.com/walidaslam7/Mapify/actions/workflows/superlinter.yml/badge.svg?branch=main)](https://github.com/walidaslam7/Mapify/actions/workflows/superlinter.yml)
<br/>

This solution provides a Geocoding API for Pakistan cities, which allows developers to easily retrieve the latitude and longitude coordinates of a given city. The API is designed to be simple and easy to use, and it can be integrated into any web or mobile application. In addition to the Geocoding API for Pakistan cities, this solution also contains World Cities JSON files, which provide latitude and longitude coordinates for cities around the world.

## Technologies

- [ASP.NET Core 7](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
- [Entity Framework Core 7](https://docs.microsoft.com/en-us/ef/core/)

## Prerequisites
- Visual Studio or any other compatible IDE
- .NET Framework or .NET Core
- OData packages installed in the project

## Installation

- Clone the repository to your local machine.
- Open the project in Visual Studio or any other compatible IDE.
- Reach out to solution directory by using ``` cd Mapify ```
- Build and run by using ``` dotnet run ``` or build the project to install the required dependencies.

## Database Configuration

The solution is configured to use an Pakistan cities data by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

Verify that the DefaultConnection connection string within appsettings.json points to a valid SQL Server instance.

If you want to run the application with World cities JSON file then latest migrations will be applied.


## Overview

This will contain all entities, Odata handling, exceptions, interfaces, logging, presistence brokers types and logic specific to the solution.

### OData Implementation in .NET WebAPI Application

This repository contains an implementation of OData in a .NET WebAPI application using the ODataConventionModelBuilder. OData is a standardized protocol for creating and consuming RESTful APIs that expose data as resources and support advanced querying capabilities.

### Usage
To use OData in your WebAPI application, you need to create an instance of ODataConventionModelBuilder and configure it to include the entities you want to expose through OData. The following code snippet shows an example of how to create the EDM model for the GeoLookup entity.

 ```csharp
  static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<GeoLookup>("Geos");
    return builder.GetEdmModel();
}
```

Once you have created the EDM model, you can enable OData in your application by adding the OData middleware to the pipeline. The following code snippet shows an example of how to configure the OData middleware in your application.

 ```csharp
builder.Services.AddControllers().AddOData(opt => opt.EnableQueryFeatures().AddRouteComponents("odata", GetEdmModel()));
```

Finally, you can use the ```[EnableQuery]``` attribute to enable advanced querying capabilities in your API controllers. The following code snippet shows an example of how to use the ```[EnableQuery]``` attribute to set the page size to 100.

 ```csharp
[EnableQuery(PageSize = 100)]
public IActionResult Get()
{
    //...
}
```

## OData Features

- ```$top``` : Retrieve only the top N records from the result set. Example: ```http://localhost:5000/odata/Geos?$top=10```.

- ```$skip```: Skip the first N records from the result set. Example: ```http://localhost:5000/odata/Geos?$skip=10```.

- ```$orderby```: Order the result set by one or more properties. You can specify the order direction using the asc or desc keyword. Example: ```http://localhost:5000/odata/Geos?$orderby=Name asc```.

- ```$count```: Include a count of the total number of records in the result set. Example: ```http://localhost:5000/odata/Geos?$count=true```.

For more information on OData and its query options, please refer to the [OData documentation](https://www.odata.org/documentation/).

## Support
If you are having problems, please let us know by [raising a new issue](https://github.com/walidaslam7/Mapify/issues/new).

## License
This project is licensed under the [MIT license](https://github.com/walidaslam7/Mapify/blob/main/LICENSE).
