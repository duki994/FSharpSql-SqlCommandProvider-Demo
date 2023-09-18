﻿module FSharpSql.CustomerQueries

open FSharp.Data

type GetById = SqlCommandProvider<
"""
    SELECT *
    FROM Customers
    WHERE CustomerId = @customerId
""", Configuration.developmentConnectionString>
