# Template DotNet Labs

## Overview

This will template to quickly start new labs or PoCs.

## Requirements

The project requires [.NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).

## Technologies, Architecture and others stuffs more

- ASP.NET Core
- Clean Architecture
- Graph Database with Neo4J
- Docker container image
- Test-Driven Development with MSTest
- Swagger

## Compatible IDEs

Tested on:

- Visual Studio Code (1.75.1)

## Useful commands

From the terminal/shell/command line tool, use the following commands to build, test and run the API.

- ### Build the project

```powershell
dotnet build
```

- ### Run the tests

```powershell
dotnet test
```

- ### Run the application

```powershell
# Run the application which will be listening on port `5099`.
dotnet run --project DotNetProject.Api
```
