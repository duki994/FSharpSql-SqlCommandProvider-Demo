module FSharpSql.Services.Customer

open FSharpSql.TypedQueries


let getById (connectionString : string) id  =
    let cmd = new CustomerQueries.GetById (connectionString)
    cmd.Execute(customerId = id)

