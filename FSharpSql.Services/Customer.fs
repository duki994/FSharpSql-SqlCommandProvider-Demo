module FSharpSql.Services.Customer

open FSharpSql.TypedQueries

let asyncGetById (connectionString : string) id =
    let cmd = new CustomerQueries.GetById (connectionString)
    cmd.AsyncExecute(customerId = id)

