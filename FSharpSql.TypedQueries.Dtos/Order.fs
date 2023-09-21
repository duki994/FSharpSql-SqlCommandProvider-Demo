namespace FSharpSql.TypedQueries.Dtos

module Order =
    open System

    module GetById =
        type Dto = 
            {
                OrderId : int
                CustomerId : string option
                EmployeeId : int option
                OrderDate : DateTime option
                RequiredDate : DateTime option
                ShippedDate : DateTime option
                ShipVia : int option
                Freight : decimal option
                ShipName : string option
                ShipAddress : string option
                ShipCity : string option
                ShipRegion : string option
                ShipPostalCode : string option
                ShipCountry : string option }

        let fromErasedType (order : FSharpSql.TypedQueries.OrderQueries.GetById.Record) : Dto =
            // map all fields
            { OrderId = order.OrderId
              CustomerId = order.CustomerId
              EmployeeId = order.EmployeeId
              OrderDate = order.OrderDate
              RequiredDate = order.RequiredDate
              ShippedDate = order.ShippedDate
              ShipVia = order.ShipVia
              Freight = order.Freight
              ShipName = order.ShipName
              ShipAddress = order.ShipAddress
              ShipCity = order.ShipCity
              ShipRegion = order.ShipRegion
              ShipPostalCode = order.ShipPostalCode
              ShipCountry = order.ShipCountry }

    module GetForCustomer = 
        type Entry = {
                OrderId : int
                CustomerId : string option
                EmployeeId : int option
                OrderDate : DateTime option
                RequiredDate : DateTime option
                ShippedDate : DateTime option
                ShipVia : int option
                Freight : decimal option
                ShipName : string option
                ShipAddress : string option
                ShipCity : string option
                ShipRegion : string option
                ShipPostalCode : string option
                ShipCountry : string option }
        type Dto = seq<Entry>

        let fromErasedType (orders : seq<FSharpSql.TypedQueries.OrderQueries.GetForCustomer.Record>) : Dto =
            // map all fields
            orders |> Seq.map (fun order -> 
                { OrderId = order.OrderId
                  CustomerId = order.CustomerId
                  EmployeeId = order.EmployeeId
                  OrderDate = order.OrderDate
                  RequiredDate = order.RequiredDate
                  ShippedDate = order.ShippedDate
                  ShipVia = order.ShipVia
                  Freight = order.Freight
                  ShipName = order.ShipName
                  ShipAddress = order.ShipAddress
                  ShipCity = order.ShipCity
                  ShipRegion = order.ShipRegion
                  ShipPostalCode = order.ShipPostalCode
                  ShipCountry = order.ShipCountry })