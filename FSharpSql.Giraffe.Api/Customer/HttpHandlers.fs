namespace FSharpSql.Giraffe.Api.Customer


module HttpHandlers =
    open Giraffe
    open FSharpSql.Services

    let getById (connectionString : string) id : HttpHandler = 
        fun next ctx ->
            task {
                let! customerResult = Customer.asyncGetById connectionString id

                return! customerResult 
                    |> Option.map (fun customer -> json customer next ctx)
                    |> Option.defaultValue ((setStatusCode 404 >=> text "Customer Not Found") next ctx)
            }

