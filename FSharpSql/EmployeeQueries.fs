module FSharpSql.TypedQueries.EmployeeQueries
open FSharp.Data

type GetEmployeeById = SqlCommandProvider<
"""
        SELECT *
        FROM Employees
        WHERE EmployeeId = @employeeId
""", Configuration.developmentConnectionString>
