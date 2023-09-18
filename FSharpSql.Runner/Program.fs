open System
open FSharpSql
open CommandLine

type Options = {
    [<Option(
        'c', 
        HelpText = "Input a connection string towards MS SQL Server DB with Northwind DB dataset", 
        Default=Configuration.developmentConnectionString)
    >] ConnectionString : string;
}

let args = Environment.GetCommandLineArgs()
let result = CommandLine.Parser.Default.ParseArguments<Options>(args) 


let printSeqAsArray seq = 
    seq
    |> Seq.toArray
    |> printfn "%A"

match result with
| :? Parsed<Options> as parsed -> 
    let options = parsed.Value
    let connectionString = options.ConnectionString
    printfn "Connection string: %s" connectionString

    let getCustomerById = connectionString |> Customer.getById
    let getOrdersForCustomer = connectionString |> Orders.getForCustomer

    printfn @"Getting customer with id ""ANATR"""
    getCustomerById "ANATR" |> printSeqAsArray

    printfn @"Getting orders for customer with id ""ANATR"""
    getOrdersForCustomer "ANATR" |> printSeqAsArray

| :? NotParsed<Options> as notParsed -> 
    printfn "Error parsing arguments: %A" notParsed
| _ -> failwith "Unexpected result from command line parser"