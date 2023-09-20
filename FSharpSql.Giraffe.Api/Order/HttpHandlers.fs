namespace FSharpSql.Giraffe.Api.Order

module HttpHandlers = 

    open Giraffe
    open FSharpSql.Services

    let getById (connectionString : string) id : HttpHandler = 
        fun next ctx ->
            let orderResult = Orders.getById connectionString id
            match orderResult with
            | Some order ->
                json order next ctx
            | None -> 
                (setStatusCode 404 >=> text "Order Not Found") next ctx

    let getForCustomer (connectionString : string) customerId : HttpHandler =
        fun next ctx -> 
            let orders = Orders.getForCustomer connectionString customerId
            json orders next ctx
        

