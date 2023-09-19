module FSharpSql.OrderQueries

open FSharp.Data

type GetById = SqlCommandProvider<
"""
        SELECT *
        FROM Orders
        WHERE OrderId = @orderId
""", Configuration.developmentConnectionString, SingleRow = true>

type GetForCustomer = SqlCommandProvider<
"""
        SELECT *
        FROM Orders
        WHERE CustomerId = @customerId
""", Configuration.developmentConnectionString>

