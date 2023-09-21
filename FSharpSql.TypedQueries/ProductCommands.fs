module FSharpSql.TypedQueries.ProductCommands

open FSharp.Data


type AddProduct = SqlCommandProvider<"""
    INSERT INTO [dbo].[Products]
           ([ProductName]
           ,[SupplierId]
           ,[CategoryId]
           ,[QuantityPerUnit]
           ,[UnitPrice]
           ,[UnitsInStock]
           ,[UnitsOnOrder]
           ,[ReorderLevel]
           ,[Discontinued])
     VALUES
           (@productName
           ,@supplierId
           ,@categoryId
           ,@quantityPerUnit
           ,@unitPrice
           ,@unitsInStock
           ,@unitsOnOrder
           ,@reorderLevel
           ,@discontinued)
""", Configuration.developmentConnectionString>


type DeleteProduct = SqlCommandProvider<"""
    BEGIN TRANSACTION;

    DELETE FROM [dbo].[Order Details]
    WHERE ProductId = @productId;

    DELETE FROM [dbo].[Products]
    WHERE ProductId = @productId;

    COMMIT;
""", Configuration.developmentConnectionString>