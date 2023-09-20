open System
open FSharpSql
open FSharpSql.Services
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


module ProductTestRun = 
    
    let execute connectionString =
        let addProduct = connectionString |> Product.add
        let deleteProduct = connectionString |> Product.delete

        printfn @"Adding product ""Test product"" to the database"
        let addition = addProduct "Test product" 1 1 "1" 1.0m (int16 1) (int16 1) (int16 1) false
        match addition with
        | Ok id -> printfn "Product added with id: %A" id
        | Error ex -> failwith (sprintf "Error adding product: %A" ex)


        let removal = 
            addition
            |> Result.bind deleteProduct
            |> Result.mapError (fun ex -> sprintf "Exception occured while deleting product: %A" ex)

        match removal with
        | Ok deletedProductId -> printfn "Successfully deleted product with `productId`: %d" deletedProductId
        | Error msg -> printfn "Error: %s" msg
        ()


module OrdersTestRun =

    let execute connectionString =
        let getOrdersForCustomer = connectionString |> Orders.getForCustomer
        printfn @"Getting orders for customer with id ""ANATR"""
        getOrdersForCustomer "ANATR" |> printSeqAsArray

        let getOrderById = connectionString |> Orders.getById
        printfn @"Getting order with id ""10248"""
        getOrderById 10248 |> printfn "%A"


module CustomerTestRun =

    let execute connectionString =
        let getCustomerById = connectionString |> Customer.getById
        printfn @"Getting customer with id ""ANATR"""
        getCustomerById "ANATR" |> printfn "%A"
        

match result with
| :? Parsed<Options> as parsed -> 
    let options = parsed.Value
    let connectionString = options.ConnectionString
    printfn "Connection string: %s" connectionString

    CustomerTestRun.execute connectionString
    OrdersTestRun.execute connectionString
    ProductTestRun.execute connectionString


| :? NotParsed<Options> as notParsed -> 
    printfn "Error parsing arguments: %A" notParsed
| _ as parserResult -> failwith (sprintf "Unexpected result from command line parser. ParserResult: %A" parserResult)