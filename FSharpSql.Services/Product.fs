module FSharpSql.Services.Product

open FSharpSql.TypedQueries


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

let asyncAdd (connectionString : string) productName supplierId categoryId quantityPerUnit unitPrice unitsInStock unitsOnOrder reorderLevel discontinued =
    async {
        try
            let cmd = new ProductCommands.AddProduct(connectionString)

            let! _ = cmd.AsyncExecute(
                productName = productName,
                supplierId = supplierId,
                categoryId = categoryId,
                quantityPerUnit = quantityPerUnit,
                unitPrice = unitPrice,
                unitsInStock = unitsInStock,
                unitsOnOrder = unitsOnOrder,
                reorderLevel = reorderLevel,
                discontinued = discontinued
            )

            return Ok ()
        with ex ->
            return Error ex
    }


let delete (connectionString : string) productId =
    try
        let cmd = new ProductCommands.DeleteProduct(connectionString)
        cmd.Execute(productId = productId) |> ignore

        Ok (productId)
    with ex ->
        Error ex

let asyncDelete (connectionString : string) productId =
    async {
        try
            let cmd = new ProductCommands.DeleteProduct(connectionString)
            let! _ = cmd.AsyncExecute(productId = productId)

            return Ok (productId)
        with ex ->
            return Error ex
    }

let getById (connectionString : string) productId = 
    let cmd = new ProductQueries.GetById(connectionString)
    cmd.Execute(productId = productId)

let asyncGetById (connectionString : string) productId =
    let cmd = new ProductQueries.GetById(connectionString)
    cmd.AsyncExecute(productId = productId)
