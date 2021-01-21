# Scaffolding `information_schema`

With this repository I want to find out if it is possible to scaffold the `information_schema` of a database. In a separate project this gave me quite a few issues where the database I was using was SQL Server 2019.

# Hypothesis

As the `information_schema` is just a set of views (as it is commonly implemented across databases) it should be trivial to use the `dotnet ef scaffold` tooling to generate models and a `DbContext` for it. Using code-first to create a table across multiple databases and using the scaffold tooling to reverse engineer the `information_schema` should allow for relatively straight forward reflection on a number of databases.

# General setup

The database I am going to test against are initially SQL Server 2019 and PG12, these will both be running in a database with clients installed on my development machine (`sqlcmd` and `psql` respectively). For easy database inspection I also use DBeaver. The databases themselves will be run using docker.

The output of `dotnet --info` is:
```
.NET SDK (reflecting any global.json):
 Version:   5.0.102
 Commit:    71365b4d42

Runtime Environment:
 OS Name:     ubuntu
 OS Version:  20.04
 OS Platform: Linux
 RID:         ubuntu.20.04-x64
 Base Path:   /home/andre/.dotnet/sdk/5.0.102/

Host (useful for support):
  Version: 5.0.2
  Commit:  cb5f173b96

.NET SDKs installed:
  3.1.404 [/home/andre/.dotnet/sdk]
  5.0.102 [/home/andre/.dotnet/sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 3.1.10 [/home/andre/.dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 5.0.2 [/home/andre/.dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 3.1.10 [/home/andre/.dotnet/shared/Microsoft.NETCore.App]
  Microsoft.NETCore.App 5.0.2 [/home/andre/.dotnet/shared/Microsoft.NETCore.App]

To install additional .NET runtimes or SDKs:
  https://aka.ms/dotnet-download
```

The data model was taken from (this)[https://blog.jetbrains.com/dotnet/2020/11/25/getting-started-with-entity-framework-core-5/] example.

# Setting up the entertainment databases

Start the databases by running `docker-compose up`.

```bash
#
# Initialize the postgres database
#
$ env PGPASSWORD='P@55word' createdb --username=postgres --host=localhost --echo entertainment
$ dotnet ef database update --context InformationSchema.Postgres.EntertainmentContext

#
# Intialize SQL Server
#
$ sqlcmd -U sa -P 'P@55word' -H localhost -e -Q 'create database Data;'
$ dotnet ef database update --context InformationSchema.SqlServer.EntertainmentContext
```



# Notes

```bash
# Creating migrations from the entertainment models
$ dotnet ef migrations add Initialize --output-dir ./Postgres/Migrations --context InformationSchema.Postgres.EntertainmentContext
```




