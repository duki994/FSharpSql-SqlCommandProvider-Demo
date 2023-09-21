module FSharpSql.Services.CSharpInterop.Customer

open FSharpSql.Services
open FSharpSql.TypedQueries.Dtos

let getByIdAsync connectionString id =
    async {
        let! customer = Customer.asyncGetById connectionString id
        return Option.map CustomerDto.GetById.fromErasedType customer
    } |> Async.StartAsTask

