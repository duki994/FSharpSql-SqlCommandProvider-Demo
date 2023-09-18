module Orders

open FSharpSql

let getById (connectionString : string) id =
    let cmd = new OrderQueries.GetById(connectionString)
    cmd.Execute(orderId = id)

let getForCustomer (connectionString : string) customerId =
    let cmd = new OrderQueries.GetForCustomer(connectionString)
    cmd.Execute(customerId = customerId)
