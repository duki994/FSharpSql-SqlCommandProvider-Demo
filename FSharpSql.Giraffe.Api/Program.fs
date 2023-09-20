module FSharpSql.Giraffe.Api.App

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Cors.Infrastructure
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open FSharpSql.Giraffe.Api.HttpHandlers
open FSharpSql.Giraffe.Api.Configuration
open Newtonsoft.Json
open Microsoft.FSharpLu.Json

// ---------------------------------
// Web app
// ---------------------------------

let webApp =
    choose [
        subRoute "/api"
            (choose [
                // a simple hello world route
                GET >=> choose [
                    route "/hello" >=> handleGetHello
                ]
                // product routes
                subRoute "/product"
                    (choose [
                        GET >=> choose [
                            routeCif "/%i" (Product.HttpHandlers.getById connectionString)
                        ]
                    ])
                // order routes
                subRoute "/order"
                    (choose [
                        GET >=> choose [
                            routeCif "/%i" (Order.HttpHandlers.getById connectionString)
                            routeCif "/for-customer/%s" (Order.HttpHandlers.getForCustomer connectionString)
                        ]
                    ])
            ])
        setStatusCode 404 >=> text "Not Found" ]

// ---------------------------------
// Error handler
// ---------------------------------

let errorHandler (ex : Exception) (logger : ILogger) =
    logger.LogError(ex, "An unhandled exception has occurred while executing the request.")
    clearResponse >=> setStatusCode 500 >=> text ex.Message

// ---------------------------------
// Config and Main
// ---------------------------------

let configureCors (builder : CorsPolicyBuilder) =
    builder
        .WithOrigins(
            "http://localhost:5000",
            "https://localhost:5001")
       .AllowAnyMethod()
       .AllowAnyHeader()
       |> ignore

let configureApp (app : IApplicationBuilder) =
    let env = app.ApplicationServices.GetService<IWebHostEnvironment>()
    (match env.IsDevelopment() with
    | true  ->
        app.UseDeveloperExceptionPage()
    | false ->
        app .UseGiraffeErrorHandler(errorHandler)
            .UseHttpsRedirection())
        .UseCors(configureCors)
        .UseGiraffe(webApp)

let configureServices (services : IServiceCollection) =
    services.AddCors()    |> ignore
    services.AddGiraffe() |> ignore
    
    let customSettings = JsonSerializerSettings()
    // serialize compact union types as strings. Especially useful for Option<'T> / option 'T types
    customSettings.Converters.Add(CompactUnionJsonConverter(true))

    services.AddSingleton<Json.ISerializer>(
        NewtonsoftJson.Serializer(customSettings)) |> ignore

let configureLogging (builder : ILoggingBuilder) =
    builder.AddConsole()
           .AddDebug() |> ignore

[<EntryPoint>]
let main args =
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .Configure(Action<IApplicationBuilder> configureApp)
                    .ConfigureServices(configureServices)
                    .ConfigureLogging(configureLogging)
                    |> ignore)
        .Build()
        .Run()
    0