namespace FSharpSql.Giraffe.Api.Product

open FSharpSql.Services

module HttpHandlers = 
    open Giraffe

    let getById connectionString id : HttpHandler =
        fun next ctx  ->
            let productResult = Product.getById connectionString id
            match productResult with
            | Some product -> json product next ctx
            | None -> (setStatusCode 204 >=> text "") next ctx

