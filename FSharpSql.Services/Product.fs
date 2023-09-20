module FSharpSql.Services.Product

open FSharpSql


let add (connectionString : string) productName supplierId categoryId quantityPerUnit unitPrice unitsInStock unitsOnOrder reorderLevel discontinued =
    try
        let cmd = new ProductCommands.AddProduct(connectionString)

        Ok (cmd.Execute(
            productName = productName,
            supplierId = supplierId,
            categoryId = categoryId,
            quantityPerUnit = quantityPerUnit,
            unitPrice = unitPrice,
            unitsInStock = unitsInStock,
            unitsOnOrder = unitsOnOrder,
            reorderLevel = reorderLevel,
            discontinued = discontinued
        ))
    with ex ->
        Error ex


let delete (connectionString : string) productId =
    try
        let cmd = new ProductCommands.DeleteProduct(connectionString)
        cmd.Execute(productId = productId) |> ignore

        Ok (productId)
    with ex ->
        Error ex

let getById (connectionString : string) productId = 
    let cmd = new ProductQueries.GetById(connectionString)
    cmd.Execute(productId = productId)

