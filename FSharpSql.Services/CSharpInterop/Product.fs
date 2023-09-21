module FSharpSql.Services.CSharpInterop.Product
open FSharpSql.Services
open FSharpSql.TypedQueries.Dtos

let getByIdAsync connectionString id =
    async {
        let! product = Product.asyncGetById connectionString id
        return Option.map ProductDto.GetById.fromErasedType product
    } |> Async.StartAsTask