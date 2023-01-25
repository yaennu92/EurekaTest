CONTENTS OF THIS FILE
---------------------

* Introduction
* About
* Installation


INTRODUCTION
------------
Blazor lets you build interactive web UIs using C# instead of JavaScript. 
Blazor apps are composed of reusable web UI components implemented using C#, HTML, and CSS. Both client and server code is written in C#, allowing you to share code and libraries.

ABOUT
-----
This is a Default Template for future Blazor Project for Data Unit. It contains MudBlazor, Microsoft Auth and Postgres connection.

INSTALLATION
------------
1. Open Project with Rider or Visual Studio
2. Run 'dotnet ef migrations add InitialCreate --project .\Profil\'
2. Run 'dotnet ef database update --project .\Profil\Profil.csproj' in Terminal (Requires **[.NET Core CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet#installing-the-tools)**)
3. Launch Application (When fails: Check in Run Configuration that docker-compose is added and enabled in _Before Launch_)

USING
-----------
This Solution can be testet with the Solutions AddressUpdate as another Microservice which can be addressed via Eureka from Profile.
As API Gateway the 'LicenseGateway' can be used.
