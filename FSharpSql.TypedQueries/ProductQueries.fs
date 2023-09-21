module FSharpSql.TypedQueries.ProductQueries

open FSharp.Data

type GetById = SqlCommandProvider<"
    SELECT * FROM [dbo].[Products] 
    WHERE ProductId = @productId
", Configuration.developmentConnectionString, SingleRow = true>

