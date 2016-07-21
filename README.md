# A simple quickstart solution for ASP.NET Core

This code base serves only to save time on initial solution setup using a simple contrived example, allowing you to 
get on to delivering value sooner instead of [bikeshedding](http://bikeshed.com/).

Take a copy, remove the hidden `.git` folder, re-`git init` and away you go!

Features:
- A vertical slice of CRUD functionality of an entity
- A domain layer
- A data layer
- Entity Framework core + migrations
- "Short" Guid generator for non-numeric URL-friendly database ID's.
- Abstracted concept of time
- App settings access class
- A basic unit test example

## ASP.NET Core Reference

[https://docs.asp.net/en/latest/tutorials/index.html](https://docs.asp.net/en/latest/tutorials/index.html)

## Entity Framework Migrations

Because we have our data layer contained in a seperate project, like sensible people do, we need to jump through a 
couple hoops for ef migrations to work properly because migrations run from dotnet core class libraries arn't 
properly supported yet.

### In Visual Studio

#### To execute the current migration:

Ensure the connection string in `appsettings.json` is correct. And ensure the solution is completely restored and re-built.

Open the `Package Manager Console`, and select `src\Embryo.Data` as the Default project. 
This should be the same project name as specified in Startup.cs class for the Entity Framework Migrations configuration. 

(NOTE: If the Data layer project name changes, the project name specified in Startup.cs will need to change too.)

Then run: `Update-Database`

### To create a new migration:

In the `Package Manager Console` ensure the Default Project is set, as above.

Run `Add-Migration <migration-name>` switching out `<migration-name>` with what you want to call the migration class.

More info on migrations @ [https://docs.efproject.net/en/latest/platforms/aspnetcore/new-db.html#create-your-database](https://docs.efproject.net/en/latest/platforms/aspnetcore/new-db.html#create-your-database)

### Outside Visual Studio

#### Running migrations from command line

If running migrations from command line is a requirement (automated deploys, etc), it's not hard to trick it into working.

Tutorial: [http://benjii.me/2016/06/entity-framework-core-migrations-for-class-library-projects/](http://benjii.me/2016/06/entity-framework-core-migrations-for-class-library-projects/)

Fingers crossed this gets better official support soon.
