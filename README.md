# FSharpSql

A demo of [FSharp.Data.SqlClient](https://github.com/fsprojects/FSharp.Data.SqlClient)'s `SqlCommandProvider` type provider.


### Prerequisites
You should have initialized and populated SQL Server 2019+ database with Northwind dataset.
SQLEXPRESS 2019 (and 2022) and LocalDB 2019 (and 2022) are tested and confirmed to work.

Be sure to set `FSharpSql.Configuration.developmentConnectionString` to target your DBs connection string.

### How to run

At the time of writing this readme, due to issues that also underly F#'s opensource implementation, but not the Visual Studio's F# compiler [#373](https://github.com/fsprojects/FSharp.Data.SqlClient/issues/373), project must be run with Visual Studio 2022.

Visual Studio 2022 works ok.
CLI tools won't work until underlying compatibility issue is fixed by MS (hopefully very soon) or when Type Provider library developers update their code.