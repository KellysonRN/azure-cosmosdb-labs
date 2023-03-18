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

## User Secrets

## Enable user secrets
```powershell
# Type from project root
dotnet user-secrets init
```

```xml
<!-- When you open the .csproj file of your project, you’ll notice 
     that a UserSecretsId element has been added as shown in the code snippet given below -->.
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <UserSecretsId>e4f51d14-ddc1-48f4-bb34-84c114e3d6d0</UserSecretsId>
  </PropertyGroup>
</Project>
```

### Set a secret
```powershell
# Type from project root
dotnet user-secrets set "PrimaryKey" "xpto@36789@#$"
```

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
