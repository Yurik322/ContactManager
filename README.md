# Contact Manager

The server side: ASP.NET Core 3.1 Web API
The client side: Angular 6


The easiest way to get started is to update database migration.
In Developer PowerShell write following:
dotnet tool install --global dotnet-ef
dotnet ef database update ContactMigration --project src\ContactManager.DAL --startup-project src\ContactManager.WebUI

Then run a project