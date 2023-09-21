namespace FSharpSql.TypedQueries.Dtos

// TODO: Investigate if FSharp Code Quotations can be used to generate. 
// Such metaprogramming approach would be more succint. And maybe way too clever for its own good.

module OrderDto =
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
        type Dto = {
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
        

        let fromErasedType (order : FSharpSql.TypedQueries.OrderQueries.GetForCustomer.Record) : Dto =
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


module CustomerDto = 
    open System

    module GetById =
        type Dto = 
            {
                CustomerId : string
                CompanyName : string
                ContactName : string option
                ContactTitle : string option
                Address : string option
                City : string option
                Region : string option
                PostalCode : string option
                Country : string option
                Phone : string option
                Fax : string option }

        let fromErasedType (customer : FSharpSql.TypedQueries.CustomerQueries.GetById.Record) : Dto =
            // map all fields
            { CustomerId = customer.CustomerId
              CompanyName = customer.CompanyName
              ContactName = customer.ContactName
              ContactTitle = customer.ContactTitle
              Address = customer.Address
              City = customer.City
              Region = customer.Region
              PostalCode = customer.PostalCode
              Country = customer.Country
              Phone = customer.Phone
              Fax = customer.Fax }


module ProductDto = 
    open System

    module GetById =
        type Dto = 
            {
                ProductId : int
                ProductName : string
                SupplierId : int option
                CategoryId : int option
                QuantityPerUnit : string option
                UnitPrice : decimal option
                UnitsInStock : int16 option
                UnitsOnOrder : int16 option
                ReorderLevel : int16 option
                Discontinued : bool }

        let fromErasedType (product : FSharpSql.TypedQueries.ProductQueries.GetById.Record) : Dto =
            // map all fields
            { ProductId = product.ProductId
              ProductName = product.ProductName
              SupplierId = product.SupplierId
              CategoryId = product.CategoryId
              QuantityPerUnit = product.QuantityPerUnit
              UnitPrice = product.UnitPrice
              UnitsInStock = product.UnitsInStock
              UnitsOnOrder = product.UnitsOnOrder
              ReorderLevel = product.ReorderLevel
              Discontinued = product.Discontinued }
