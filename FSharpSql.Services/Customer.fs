module FSharpSql.Services.Customer

open FSharpSql


let getById (connectionString : string) id  =
    let cmd = new CustomerQueries.GetById (connectionString)
    cmd.Execute(customerId = id)

