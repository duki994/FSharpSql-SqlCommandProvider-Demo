module FSharpSql.Services.CSharpInterop.Orders

open FSharpSql.Services
open FSharpSql.TypedQueries.Dtos


let getByIdAsync connectionString id =
    async {
        let! order = Orders.asyncGetById connectionString id
        return Option.map OrderDto.GetById.fromErasedType order
    } |> Async.StartAsTask

let getForCustomerAsync connectionString id =
    async {
        let! orders = Orders.asyncGetForCustomer connectionString id
        return orders |> Seq.map OrderDto.GetForCustomer.fromErasedType
    } |> Async.StartAsTask
