namespace FSharpSql.Giraffe.Api.Order

module HttpHandlers = 

    open Giraffe
    open FSharpSql.Services

    let getById (connectionString : string) id : HttpHandler = 
        fun next ctx ->
            task {
                let! orderResult = Orders.asyncGetById connectionString id
                match orderResult with
                | Some order ->
                    return! json order next ctx
                | None -> 
                    return! (setStatusCode 404 >=> text "Order Not Found") next ctx
            }

    let getForCustomer (connectionString : string) customerId : HttpHandler =
        fun next ctx -> 
            task {
                let! orders = Orders.asyncGetForCustomer connectionString customerId
                return! json orders next ctx
            }
        

