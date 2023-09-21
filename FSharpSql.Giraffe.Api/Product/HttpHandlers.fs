namespace FSharpSql.Giraffe.Api.Product

open FSharpSql.Services

module HttpHandlers = 
    open Giraffe

    let getById connectionString id : HttpHandler =
        fun next ctx  ->
            task {
                let! productResult = Product.asyncGetById connectionString id

                return! productResult
                    |> Option.map (fun product -> json product next ctx)
                    |> Option.defaultValue ((setStatusCode 204 >=> text "") next ctx)
            }

