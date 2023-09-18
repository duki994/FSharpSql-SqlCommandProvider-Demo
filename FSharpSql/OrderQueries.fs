module FSharpSql.OrderQueries

open FSharp.Data

type GetById = SqlCommandProvider<
"""
        SELECT *
        FROM Orders
        WHERE OrderId = @orderId
""", Configuration.developmentConnectionString>

type GetForCustomer = SqlCommandProvider<
"""
        SELECT *
        FROM Orders
        WHERE CustomerId = @customerId
""", Configuration.developmentConnectionString>

