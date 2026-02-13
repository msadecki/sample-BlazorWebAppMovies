# Sample source - Build a Blazor movie database app (Overview)

https://learn.microsoft.com/en-us/aspnet/core/blazor/tutorials/movie-database-app/?view=aspnetcore-10.0

# How to add a new EF migration

## Prerequisites - Ensure EF Core Tools are installed
```
PowerShell
Install-Package Microsoft.EntityFrameworkCore.Tools
```
Do this in BlazorWebAppMovies (future improvements - in both Some.DataAccess & Some.WebApp) if needed.

## Steps in Visual Studio

### Set the Startup Project
In Solution Explorer, right-click BlazorWebAppMovies and choose Set as Startup Project.
This ensures EF Core uses the correct configuration and Program.cs for dependency injection.

### Open the Package Manager Console (PMC)
Go to Tools → NuGet Package Manager → Package Manager Console.

### Prepare some change to be updated
Add new domain model class (consider : IEntity) and new DbSet to BlazorWebAppMoviesContext or change existing domain model class.

### Run the Migration Command in PMC
```
PowerShell
Add-Migration AddSomeTable
```
Explanation:
- Add-Migration AddSomeTable → Creates a migration named AddSomeTable in the only one project from solution

### Run the Migration Command in PMC - future improvements
```
PowerShell
Add-Migration AddSomeTable -Project Some.DataAccess -StartupProject Some.WebApp
```
Explanation:
- Add-Migration AddSomeTable → Creates a migration named AddSomeTable.
- -Project Some.DataAccess → The project where your DbContext and migrations live.
- -StartupProject Some.WebApp → The project that provides configuration and services.