namespace FSharpSql.Giraffe.Api

module HttpHandlers =

    open Microsoft.AspNetCore.Http
    open Giraffe
    open FSharpSql.Giraffe.Api.Models

    let handleGetHello =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let response = {
                    Text = "Hello world, from Giraffe!"
                }
                return! json response next ctx
            }