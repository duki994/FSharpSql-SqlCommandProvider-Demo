namespace FSharpSql.Giraffe.Api.Order

module HttpHandlers = 

    open Giraffe
    open FSharpSql.Services

    let getById (connectionString : string) id : HttpHandler = 
        fun next ctx ->
            task {
                let! orderResult = Orders.asyncGetById connectionString id

                return! orderResult
                    |> Option.map (fun order -> json order next ctx)
                    |> Option.defaultValue ((setStatusCode 404 >=> text "Order Not Found") next ctx)
            }

    let getForCustomer (connectionString : string) customerId : HttpHandler =
        fun next ctx -> 
            task {
                let! orders = Orders.asyncGetForCustomer connectionString customerId
                return! json orders next ctx
            }
        

