# Quick start

This code base serves only to save time on the initial solution setup, allowing you to get on to delivering value sooner instead of bikeshedding.

Take a copy and away you go!

Features:
- A vertical slice of CRUD functionality of an entity
- A domain layer
- A data layer
- Entity Framework core + migrations
- "Short" Guid generator for non-numeric URL-friendly database ID's.
- Abstracted concept of time
- App settings access class
- Basic unit test examples

## Entity Framework Migrations

### To execute the current migration:

Ensure the connection string in `appsettings.json` is correct. And ensure the solution is completely restored and re-built.

Open the `Package Manager Console`, and select `src\Embryo.Data` as the Default project. 
This should be the same project name as specified in Startup.cs class for the Entity Framework Migrations configuration. 

(NOTE: If the Data layer project name changes, the project name specified in Startup.cs will need to change too.)

Then run: `Update-Database`

### To create a new migration:

In the `Package Manager Console` ensure the Default Project is set, as above.

Run `Add-Migration <migration-name>` switching out `<migration-name>` with what you want to call the migration class.

More info on migrations @ [https://docs.efproject.net/en/latest/platforms/aspnetcore/new-db.html#create-your-database](https://docs.efproject.net/en/latest/platforms/aspnetcore/new-db.html#create-your-database)

### Running migrations from command line

Unfortunately, Entity Framework Core 1.0.0 RTM still does not support migrations for class library projects 
(which we have our data layer contained in, like sensible people do), yet.
But it's not too hard to trick it into working, if running from command line is a requirement (automated deploys, etc).

Here's how: [http://benjii.me/2016/06/entity-framework-core-migrations-for-class-library-projects/](http://benjii.me/2016/06/entity-framework-core-migrations-for-class-library-projects/)
