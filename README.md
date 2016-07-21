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

To generate the database schema required for this project, ef migrations must be run.

Requires a SQL database server and a login with `create database` permissions.

### Running database migrations in VS

Ensure the connection string in `appsettings.json` is correct. And ensure the entire solution is completely restored and re-built.

Open the `Package Manager Console`, and select `src\Embryo.Data` as the Default project. 

Then run: `Update-Database`.

If it can't find the command, try rebuilding the entire solution, and/or restarting VS.

### Running database migrations from the command line

If running migrations from command line is a requirement (automated deploys, etc), we need to do a couple magic tricks:

[http://benjii.me/2016/06/entity-framework-core-migrations-for-class-library-projects/](http://benjii.me/2016/06/entity-framework-core-migrations-for-class-library-projects/)

Fingers crossed this gets better official support soon.

### More on ef migrations

[https://docs.efproject.net/en/latest/platforms/aspnetcore/new-db.html#create-your-database](https://docs.efproject.net/en/latest/platforms/aspnetcore/new-db.html#create-your-database)
