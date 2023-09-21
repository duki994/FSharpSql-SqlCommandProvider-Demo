namespace FSharpSql.Giraffe.Api.Product

open FSharpSql.Services

module HttpHandlers = 
    open Giraffe

    let getById connectionString id : HttpHandler =
        fun next ctx  ->
            task {
                let! productResult = Product.asyncGetById connectionString id

                match productResult with
                | Some product -> return! json product next ctx
                | None -> return! (setStatusCode 204 >=> text "") next ctx
            }

