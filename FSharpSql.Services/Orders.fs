module FSharpSql.Services.Orders

open FSharpSql.TypedQueries

let asyncGetById (connectionString : string) id =
    let cmd = new OrderQueries.GetById(connectionString)
    cmd.AsyncExecute(orderId = id)

let asyncGetForCustomer (connectionString : string) customerId =
    let cmd = new OrderQueries.GetForCustomer(connectionString)
    cmd.AsyncExecute(customerId = customerId)
