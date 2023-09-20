module FSharpSql.Services.Orders

open FSharpSql.TypedQueries

let getById (connectionString : string) id =
    let cmd = new OrderQueries.GetById(connectionString)
    cmd.Execute(orderId = id)

let getForCustomer (connectionString : string) customerId =
    let cmd = new OrderQueries.GetForCustomer(connectionString)
    cmd.Execute(customerId = customerId)
