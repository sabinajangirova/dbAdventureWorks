namespace dbAdventureWorks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Person.Address",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(nullable: false, maxLength: 60),
                        AddressLine2 = c.String(maxLength: 60),
                        City = c.String(nullable: false, maxLength: 30),
                        StateProvinceID = c.Int(nullable: false),
                        PostalCode = c.String(nullable: false, maxLength: 15),
                        SpatialLocation = c.Geography(),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("Person.StateProvince", t => t.StateProvinceID)
                .Index(t => t.StateProvinceID);
            
            CreateTable(
                "Person.BusinessEntityAddress",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                        AddressTypeID = c.Int(nullable: false),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessEntityID, t.AddressID, t.AddressTypeID })
                .ForeignKey("Person.AddressType", t => t.AddressTypeID)
                .ForeignKey("Person.BusinessEntity", t => t.BusinessEntityID)
                .ForeignKey("Person.Address", t => t.AddressID)
                .Index(t => t.BusinessEntityID)
                .Index(t => t.AddressID)
                .Index(t => t.AddressTypeID);
            
            CreateTable(
                "Person.AddressType",
                c => new
                    {
                        AddressTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddressTypeID);
            
            CreateTable(
                "Person.BusinessEntity",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false, identity: true),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessEntityID);
            
            CreateTable(
                "Person.BusinessEntityContact",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                        ContactTypeID = c.Int(nullable: false),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessEntityID, t.PersonID, t.ContactTypeID })
                .ForeignKey("Person.ContactType", t => t.ContactTypeID)
                .ForeignKey("Person.Person", t => t.PersonID)
                .ForeignKey("Person.BusinessEntity", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID)
                .Index(t => t.PersonID)
                .Index(t => t.ContactTypeID);
            
            CreateTable(
                "Person.ContactType",
                c => new
                    {
                        ContactTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactTypeID);
            
            CreateTable(
                "Person.Person",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        PersonType = c.String(nullable: false, maxLength: 2, fixedLength: true),
                        NameStyle = c.Boolean(nullable: false),
                        Title = c.String(maxLength: 8),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Suffix = c.String(maxLength: 10),
                        EmailPromotion = c.Int(nullable: false),
                        AdditionalContactInfo = c.String(storeType: "xml"),
                        Demographics = c.String(storeType: "xml"),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessEntityID)
                .ForeignKey("Person.BusinessEntity", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID);
            
            CreateTable(
                "Sales.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        PersonID = c.Int(),
                        StoreID = c.Int(),
                        TerritoryID = c.Int(),
                        AccountNumber = c.String(nullable: false, maxLength: 10, unicode: false),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("Sales.SalesTerritory", t => t.TerritoryID)
                .ForeignKey("Sales.Store", t => t.StoreID)
                .ForeignKey("Person.Person", t => t.PersonID)
                .Index(t => t.PersonID)
                .Index(t => t.StoreID)
                .Index(t => t.TerritoryID);
            
            CreateTable(
                "Sales.SalesOrderHeader",
                c => new
                    {
                        SalesOrderID = c.Int(nullable: false, identity: true),
                        RevisionNumber = c.Byte(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        ShipDate = c.DateTime(),
                        Status = c.Byte(nullable: false),
                        OnlineOrderFlag = c.Boolean(nullable: false),
                        SalesOrderNumber = c.String(nullable: false, maxLength: 25),
                        PurchaseOrderNumber = c.String(maxLength: 25),
                        AccountNumber = c.String(maxLength: 15),
                        CustomerID = c.Int(nullable: false),
                        SalesPersonID = c.Int(),
                        TerritoryID = c.Int(),
                        BillToAddressID = c.Int(nullable: false),
                        ShipToAddressID = c.Int(nullable: false),
                        ShipMethodID = c.Int(nullable: false),
                        CreditCardID = c.Int(),
                        CreditCardApprovalCode = c.String(maxLength: 15, unicode: false),
                        CurrencyRateID = c.Int(),
                        SubTotal = c.Decimal(nullable: false, storeType: "money"),
                        TaxAmt = c.Decimal(nullable: false, storeType: "money"),
                        Freight = c.Decimal(nullable: false, storeType: "money"),
                        TotalDue = c.Decimal(nullable: false, storeType: "money"),
                        Comment = c.String(maxLength: 128),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalesOrderID)
                .ForeignKey("Sales.CreditCard", t => t.CreditCardID)
                .ForeignKey("Sales.SalesTerritory", t => t.TerritoryID)
                .ForeignKey("Purchasing.ShipMethod", t => t.ShipMethodID)
                .ForeignKey("Sales.SalesPerson", t => t.SalesPersonID)
                .ForeignKey("Sales.CurrencyRate", t => t.CurrencyRateID)
                .ForeignKey("Sales.Customer", t => t.CustomerID)
                .ForeignKey("Person.Address", t => t.BillToAddressID)
                .ForeignKey("Person.Address", t => t.ShipToAddressID)
                .Index(t => t.CustomerID)
                .Index(t => t.SalesPersonID)
                .Index(t => t.TerritoryID)
                .Index(t => t.BillToAddressID)
                .Index(t => t.ShipToAddressID)
                .Index(t => t.ShipMethodID)
                .Index(t => t.CreditCardID)
                .Index(t => t.CurrencyRateID);
            
            CreateTable(
                "Sales.CreditCard",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        CardType = c.String(nullable: false, maxLength: 50),
                        CardNumber = c.String(nullable: false, maxLength: 25),
                        ExpMonth = c.Byte(nullable: false),
                        ExpYear = c.Short(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardID);
            
            CreateTable(
                "Sales.PersonCreditCard",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        CreditCardID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessEntityID, t.CreditCardID })
                .ForeignKey("Sales.CreditCard", t => t.CreditCardID)
                .ForeignKey("Person.Person", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID)
                .Index(t => t.CreditCardID);
            
            CreateTable(
                "Sales.CurrencyRate",
                c => new
                    {
                        CurrencyRateID = c.Int(nullable: false, identity: true),
                        CurrencyRateDate = c.DateTime(nullable: false),
                        FromCurrencyCode = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        ToCurrencyCode = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        AverageRate = c.Decimal(nullable: false, storeType: "money"),
                        EndOfDayRate = c.Decimal(nullable: false, storeType: "money"),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyRateID)
                .ForeignKey("Sales.Currency", t => t.FromCurrencyCode)
                .ForeignKey("Sales.Currency", t => t.ToCurrencyCode)
                .Index(t => t.FromCurrencyCode)
                .Index(t => t.ToCurrencyCode);
            
            CreateTable(
                "Sales.Currency",
                c => new
                    {
                        CurrencyCode = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyCode);
            
            CreateTable(
                "Sales.CountryRegionCurrency",
                c => new
                    {
                        CountryRegionCode = c.String(nullable: false, maxLength: 3),
                        CurrencyCode = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CountryRegionCode, t.CurrencyCode })
                .ForeignKey("Person.CountryRegion", t => t.CountryRegionCode)
                .ForeignKey("Sales.Currency", t => t.CurrencyCode)
                .Index(t => t.CountryRegionCode)
                .Index(t => t.CurrencyCode);
            
            CreateTable(
                "Person.CountryRegion",
                c => new
                    {
                        CountryRegionCode = c.String(nullable: false, maxLength: 3),
                        Name = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CountryRegionCode);
            
            CreateTable(
                "Sales.SalesTerritory",
                c => new
                    {
                        TerritoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CountryRegionCode = c.String(nullable: false, maxLength: 3),
                        Group = c.String(nullable: false, maxLength: 50),
                        SalesYTD = c.Decimal(nullable: false, storeType: "money"),
                        SalesLastYear = c.Decimal(nullable: false, storeType: "money"),
                        CostYTD = c.Decimal(nullable: false, storeType: "money"),
                        CostLastYear = c.Decimal(nullable: false, storeType: "money"),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TerritoryID)
                .ForeignKey("Person.CountryRegion", t => t.CountryRegionCode)
                .Index(t => t.CountryRegionCode);
            
            CreateTable(
                "Sales.SalesPerson",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        TerritoryID = c.Int(),
                        SalesQuota = c.Decimal(storeType: "money"),
                        Bonus = c.Decimal(nullable: false, storeType: "money"),
                        CommissionPct = c.Decimal(nullable: false, storeType: "smallmoney"),
                        SalesYTD = c.Decimal(nullable: false, storeType: "money"),
                        SalesLastYear = c.Decimal(nullable: false, storeType: "money"),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessEntityID)
                .ForeignKey("HumanResources.Employee", t => t.BusinessEntityID)
                .ForeignKey("Sales.SalesTerritory", t => t.TerritoryID)
                .Index(t => t.BusinessEntityID)
                .Index(t => t.TerritoryID);
            
            CreateTable(
                "HumanResources.Employee",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        NationalIDNumber = c.String(nullable: false, maxLength: 15),
                        LoginID = c.String(nullable: false, maxLength: 256),
                        OrganizationLevel = c.Short(),
                        JobTitle = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        MaritalStatus = c.String(nullable: false, maxLength: 1, fixedLength: true),
                        Gender = c.String(nullable: false, maxLength: 1, fixedLength: true),
                        HireDate = c.DateTime(nullable: false, storeType: "date"),
                        SalariedFlag = c.Boolean(nullable: false),
                        VacationHours = c.Short(nullable: false),
                        SickLeaveHours = c.Short(nullable: false),
                        CurrentFlag = c.Boolean(nullable: false),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessEntityID)
                .ForeignKey("Person.Person", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID);
            
            CreateTable(
                "HumanResources.EmployeeDepartmentHistory",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        DepartmentID = c.Short(nullable: false),
                        ShiftID = c.Byte(nullable: false),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(storeType: "date"),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessEntityID, t.DepartmentID, t.ShiftID, t.StartDate })
                .ForeignKey("HumanResources.Department", t => t.DepartmentID)
                .ForeignKey("HumanResources.Shift", t => t.ShiftID)
                .ForeignKey("HumanResources.Employee", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID)
                .Index(t => t.DepartmentID)
                .Index(t => t.ShiftID);
            
            CreateTable(
                "HumanResources.Department",
                c => new
                    {
                        DepartmentID = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        GroupName = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "HumanResources.Shift",
                c => new
                    {
                        ShiftID = c.Byte(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftID);
            
            CreateTable(
                "HumanResources.EmployeePayHistory",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        RateChangeDate = c.DateTime(nullable: false),
                        Rate = c.Decimal(nullable: false, storeType: "money"),
                        PayFrequency = c.Byte(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessEntityID, t.RateChangeDate })
                .ForeignKey("HumanResources.Employee", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID);
            
            CreateTable(
                "HumanResources.JobCandidate",
                c => new
                    {
                        JobCandidateID = c.Int(nullable: false, identity: true),
                        BusinessEntityID = c.Int(),
                        Resume = c.String(storeType: "xml"),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.JobCandidateID)
                .ForeignKey("HumanResources.Employee", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID);
            
            CreateTable(
                "Purchasing.PurchaseOrderHeader",
                c => new
                    {
                        PurchaseOrderID = c.Int(nullable: false, identity: true),
                        RevisionNumber = c.Byte(nullable: false),
                        Status = c.Byte(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        VendorID = c.Int(nullable: false),
                        ShipMethodID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        ShipDate = c.DateTime(),
                        SubTotal = c.Decimal(nullable: false, storeType: "money"),
                        TaxAmt = c.Decimal(nullable: false, storeType: "money"),
                        Freight = c.Decimal(nullable: false, storeType: "money"),
                        TotalDue = c.Decimal(nullable: false, storeType: "money"),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseOrderID)
                .ForeignKey("Purchasing.ShipMethod", t => t.ShipMethodID)
                .ForeignKey("Purchasing.Vendor", t => t.VendorID)
                .ForeignKey("HumanResources.Employee", t => t.EmployeeID)
                .Index(t => t.EmployeeID)
                .Index(t => t.VendorID)
                .Index(t => t.ShipMethodID);
            
            CreateTable(
                "Purchasing.PurchaseOrderDetail",
                c => new
                    {
                        PurchaseOrderID = c.Int(nullable: false),
                        PurchaseOrderDetailID = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        OrderQty = c.Short(nullable: false),
                        ProductID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        LineTotal = c.Decimal(nullable: false, storeType: "money"),
                        ReceivedQty = c.Decimal(nullable: false, precision: 8, scale: 2),
                        RejectedQty = c.Decimal(nullable: false, precision: 8, scale: 2),
                        StockedQty = c.Decimal(nullable: false, precision: 9, scale: 2),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.PurchaseOrderID, t.PurchaseOrderDetailID })
                .ForeignKey("Purchasing.PurchaseOrderHeader", t => t.PurchaseOrderID)
                .Index(t => t.PurchaseOrderID);
            
            CreateTable(
                "Purchasing.ShipMethod",
                c => new
                    {
                        ShipMethodID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ShipBase = c.Decimal(nullable: false, storeType: "money"),
                        ShipRate = c.Decimal(nullable: false, storeType: "money"),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShipMethodID);
            
            CreateTable(
                "Purchasing.Vendor",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        AccountNumber = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreditRating = c.Byte(nullable: false),
                        PreferredVendorStatus = c.Boolean(nullable: false),
                        ActiveFlag = c.Boolean(nullable: false),
                        PurchasingWebServiceURL = c.String(maxLength: 1024),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessEntityID)
                .ForeignKey("Person.BusinessEntity", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID);
            
            CreateTable(
                "Purchasing.ProductVendor",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        BusinessEntityID = c.Int(nullable: false),
                        AverageLeadTime = c.Int(nullable: false),
                        StandardPrice = c.Decimal(nullable: false, storeType: "money"),
                        LastReceiptCost = c.Decimal(storeType: "money"),
                        LastReceiptDate = c.DateTime(),
                        MinOrderQty = c.Int(nullable: false),
                        MaxOrderQty = c.Int(nullable: false),
                        OnOrderQty = c.Int(),
                        UnitMeasureCode = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.BusinessEntityID })
                .ForeignKey("Purchasing.Vendor", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID);
            
            CreateTable(
                "Sales.SalesPersonQuotaHistory",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        QuotaDate = c.DateTime(nullable: false),
                        SalesQuota = c.Decimal(nullable: false, storeType: "money"),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessEntityID, t.QuotaDate })
                .ForeignKey("Sales.SalesPerson", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID);
            
            CreateTable(
                "Sales.SalesTerritoryHistory",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        TerritoryID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessEntityID, t.TerritoryID, t.StartDate })
                .ForeignKey("Sales.SalesPerson", t => t.BusinessEntityID)
                .ForeignKey("Sales.SalesTerritory", t => t.TerritoryID)
                .Index(t => t.BusinessEntityID)
                .Index(t => t.TerritoryID);
            
            CreateTable(
                "Sales.Store",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        SalesPersonID = c.Int(),
                        Demographics = c.String(storeType: "xml"),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessEntityID)
                .ForeignKey("Sales.SalesPerson", t => t.SalesPersonID)
                .ForeignKey("Person.BusinessEntity", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID)
                .Index(t => t.SalesPersonID);
            
            CreateTable(
                "Person.StateProvince",
                c => new
                    {
                        StateProvinceID = c.Int(nullable: false, identity: true),
                        StateProvinceCode = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        CountryRegionCode = c.String(nullable: false, maxLength: 3),
                        IsOnlyStateProvinceFlag = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        TerritoryID = c.Int(nullable: false),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StateProvinceID)
                .ForeignKey("Sales.SalesTerritory", t => t.TerritoryID)
                .ForeignKey("Person.CountryRegion", t => t.CountryRegionCode)
                .Index(t => t.CountryRegionCode)
                .Index(t => t.TerritoryID);
            
            CreateTable(
                "Sales.SalesTaxRate",
                c => new
                    {
                        SalesTaxRateID = c.Int(nullable: false, identity: true),
                        StateProvinceID = c.Int(nullable: false),
                        TaxType = c.Byte(nullable: false),
                        TaxRate = c.Decimal(nullable: false, storeType: "smallmoney"),
                        Name = c.String(nullable: false, maxLength: 50),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalesTaxRateID)
                .ForeignKey("Person.StateProvince", t => t.StateProvinceID)
                .Index(t => t.StateProvinceID);
            
            CreateTable(
                "Sales.SalesOrderDetail",
                c => new
                    {
                        SalesOrderID = c.Int(nullable: false),
                        SalesOrderDetailID = c.Int(nullable: false),
                        CarrierTrackingNumber = c.String(maxLength: 25),
                        OrderQty = c.Short(nullable: false),
                        ProductID = c.Int(nullable: false),
                        SpecialOfferID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        UnitPriceDiscount = c.Decimal(nullable: false, storeType: "money"),
                        LineTotal = c.Decimal(nullable: false, precision: 38, scale: 6, storeType: "numeric"),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.SalesOrderID, t.SalesOrderDetailID })
                .ForeignKey("Sales.SalesOrderHeader", t => t.SalesOrderID, cascadeDelete: true)
                .ForeignKey("Sales.SpecialOfferProduct", t => new { t.SpecialOfferID, t.ProductID })
                .Index(t => t.SalesOrderID)
                .Index(t => new { t.SpecialOfferID, t.ProductID });
            
            CreateTable(
                "Sales.SpecialOfferProduct",
                c => new
                    {
                        SpecialOfferID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.SpecialOfferID, t.ProductID })
                .ForeignKey("Sales.SpecialOffer", t => t.SpecialOfferID)
                .Index(t => t.SpecialOfferID);
            
            CreateTable(
                "Sales.SpecialOffer",
                c => new
                    {
                        SpecialOfferID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        DiscountPct = c.Decimal(nullable: false, storeType: "smallmoney"),
                        Type = c.String(nullable: false, maxLength: 50),
                        Category = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        MinQty = c.Int(nullable: false),
                        MaxQty = c.Int(),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialOfferID);
            
            CreateTable(
                "Sales.SalesOrderHeaderSalesReason",
                c => new
                    {
                        SalesOrderID = c.Int(nullable: false),
                        SalesReasonID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.SalesOrderID, t.SalesReasonID })
                .ForeignKey("Sales.SalesOrderHeader", t => t.SalesOrderID, cascadeDelete: true)
                .ForeignKey("Sales.SalesReason", t => t.SalesReasonID)
                .Index(t => t.SalesOrderID)
                .Index(t => t.SalesReasonID);
            
            CreateTable(
                "Sales.SalesReason",
                c => new
                    {
                        SalesReasonID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ReasonType = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalesReasonID);
            
            CreateTable(
                "Person.EmailAddress",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        EmailAddressID = c.Int(nullable: false),
                        EmailAddress = c.String(maxLength: 50),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessEntityID, t.EmailAddressID })
                .ForeignKey("Person.Person", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID);
            
            CreateTable(
                "Person.Password",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        PasswordHash = c.String(nullable: false, maxLength: 128, unicode: false),
                        PasswordSalt = c.String(nullable: false, maxLength: 10, unicode: false),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessEntityID)
                .ForeignKey("Person.Person", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID);
            
            CreateTable(
                "Person.PersonPhone",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 25),
                        PhoneNumberTypeID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusinessEntityID, t.PhoneNumber, t.PhoneNumberTypeID })
                .ForeignKey("Person.PhoneNumberType", t => t.PhoneNumberTypeID)
                .ForeignKey("Person.Person", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID)
                .Index(t => t.PhoneNumberTypeID);
            
            CreateTable(
                "Person.PhoneNumberType",
                c => new
                    {
                        PhoneNumberTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneNumberTypeID);
            
            CreateTable(
                "dbo.AWBuildVersion",
                c => new
                    {
                        SystemInformationID = c.Byte(nullable: false, identity: true),
                        DatabaseVersion = c.String(name: "Database Version", nullable: false, maxLength: 25),
                        VersionDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SystemInformationID);
            
            CreateTable(
                "Production.BillOfMaterials",
                c => new
                    {
                        BillOfMaterialsID = c.Int(nullable: false, identity: true),
                        ProductAssemblyID = c.Int(),
                        ComponentID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        UnitMeasureCode = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        BOMLevel = c.Short(nullable: false),
                        PerAssemblyQty = c.Decimal(nullable: false, precision: 8, scale: 2),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BillOfMaterialsID)
                .ForeignKey("Production.Product", t => t.ComponentID)
                .ForeignKey("Production.Product", t => t.ProductAssemblyID)
                .ForeignKey("Production.UnitMeasure", t => t.UnitMeasureCode)
                .Index(t => t.ProductAssemblyID)
                .Index(t => t.ComponentID)
                .Index(t => t.UnitMeasureCode);
            
            CreateTable(
                "Production.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ProductNumber = c.String(nullable: false, maxLength: 25),
                        MakeFlag = c.Boolean(nullable: false),
                        FinishedGoodsFlag = c.Boolean(nullable: false),
                        Color = c.String(maxLength: 15),
                        SafetyStockLevel = c.Short(nullable: false),
                        ReorderPoint = c.Short(nullable: false),
                        StandardCost = c.Decimal(nullable: false, storeType: "money"),
                        ListPrice = c.Decimal(nullable: false, storeType: "money"),
                        Size = c.String(maxLength: 5),
                        SizeUnitMeasureCode = c.String(maxLength: 3, fixedLength: true),
                        WeightUnitMeasureCode = c.String(maxLength: 3, fixedLength: true),
                        Weight = c.Decimal(precision: 8, scale: 2),
                        DaysToManufacture = c.Int(nullable: false),
                        ProductLine = c.String(maxLength: 2, fixedLength: true),
                        Class = c.String(maxLength: 2, fixedLength: true),
                        Style = c.String(maxLength: 2, fixedLength: true),
                        ProductSubcategoryID = c.Int(),
                        ProductModelID = c.Int(),
                        SellStartDate = c.DateTime(nullable: false),
                        SellEndDate = c.DateTime(),
                        DiscontinuedDate = c.DateTime(),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("Production.ProductModel", t => t.ProductModelID)
                .ForeignKey("Production.ProductSubcategory", t => t.ProductSubcategoryID)
                .ForeignKey("Production.UnitMeasure", t => t.SizeUnitMeasureCode)
                .ForeignKey("Production.UnitMeasure", t => t.WeightUnitMeasureCode)
                .Index(t => t.SizeUnitMeasureCode)
                .Index(t => t.WeightUnitMeasureCode)
                .Index(t => t.ProductSubcategoryID)
                .Index(t => t.ProductModelID);
            
            CreateTable(
                "Production.ProductCostHistory",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        StandardCost = c.Decimal(nullable: false, storeType: "money"),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.StartDate })
                .ForeignKey("Production.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "Production.ProductDocument",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("Production.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "Production.ProductInventory",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        LocationID = c.Short(nullable: false),
                        Shelf = c.String(nullable: false, maxLength: 10),
                        Bin = c.Byte(nullable: false),
                        Quantity = c.Short(nullable: false),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.LocationID })
                .ForeignKey("Production.Location", t => t.LocationID)
                .ForeignKey("Production.Product", t => t.ProductID)
                .Index(t => t.ProductID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "Production.Location",
                c => new
                    {
                        LocationID = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CostRate = c.Decimal(nullable: false, storeType: "smallmoney"),
                        Availability = c.Decimal(nullable: false, precision: 8, scale: 2),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "Production.WorkOrderRouting",
                c => new
                    {
                        WorkOrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        OperationSequence = c.Short(nullable: false),
                        LocationID = c.Short(nullable: false),
                        ScheduledStartDate = c.DateTime(nullable: false),
                        ScheduledEndDate = c.DateTime(nullable: false),
                        ActualStartDate = c.DateTime(),
                        ActualEndDate = c.DateTime(),
                        ActualResourceHrs = c.Decimal(precision: 9, scale: 4),
                        PlannedCost = c.Decimal(nullable: false, storeType: "money"),
                        ActualCost = c.Decimal(storeType: "money"),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkOrderID, t.ProductID, t.OperationSequence })
                .ForeignKey("Production.WorkOrder", t => t.WorkOrderID)
                .ForeignKey("Production.Location", t => t.LocationID)
                .Index(t => t.WorkOrderID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "Production.WorkOrder",
                c => new
                    {
                        WorkOrderID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        OrderQty = c.Int(nullable: false),
                        StockedQty = c.Int(nullable: false),
                        ScrappedQty = c.Short(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        DueDate = c.DateTime(nullable: false),
                        ScrapReasonID = c.Short(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WorkOrderID)
                .ForeignKey("Production.ScrapReason", t => t.ScrapReasonID)
                .ForeignKey("Production.Product", t => t.ProductID)
                .Index(t => t.ProductID)
                .Index(t => t.ScrapReasonID);
            
            CreateTable(
                "Production.ScrapReason",
                c => new
                    {
                        ScrapReasonID = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ScrapReasonID);
            
            CreateTable(
                "Production.ProductListPriceHistory",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        ListPrice = c.Decimal(nullable: false, storeType: "money"),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.StartDate })
                .ForeignKey("Production.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "Production.ProductModel",
                c => new
                    {
                        ProductModelID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CatalogDescription = c.String(storeType: "xml"),
                        Instructions = c.String(storeType: "xml"),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductModelID);
            
            CreateTable(
                "Production.ProductModelIllustration",
                c => new
                    {
                        ProductModelID = c.Int(nullable: false),
                        IllustrationID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductModelID, t.IllustrationID })
                .ForeignKey("Production.Illustration", t => t.IllustrationID)
                .ForeignKey("Production.ProductModel", t => t.ProductModelID)
                .Index(t => t.ProductModelID)
                .Index(t => t.IllustrationID);
            
            CreateTable(
                "Production.Illustration",
                c => new
                    {
                        IllustrationID = c.Int(nullable: false, identity: true),
                        Diagram = c.String(storeType: "xml"),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IllustrationID);
            
            CreateTable(
                "Production.ProductModelProductDescriptionCulture",
                c => new
                    {
                        ProductModelID = c.Int(nullable: false),
                        ProductDescriptionID = c.Int(nullable: false),
                        CultureID = c.String(nullable: false, maxLength: 6, fixedLength: true),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductModelID, t.ProductDescriptionID, t.CultureID })
                .ForeignKey("Production.Culture", t => t.CultureID)
                .ForeignKey("Production.ProductDescription", t => t.ProductDescriptionID)
                .ForeignKey("Production.ProductModel", t => t.ProductModelID)
                .Index(t => t.ProductModelID)
                .Index(t => t.ProductDescriptionID)
                .Index(t => t.CultureID);
            
            CreateTable(
                "Production.Culture",
                c => new
                    {
                        CultureID = c.String(nullable: false, maxLength: 6, fixedLength: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CultureID);
            
            CreateTable(
                "Production.ProductDescription",
                c => new
                    {
                        ProductDescriptionID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 400),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductDescriptionID);
            
            CreateTable(
                "Production.ProductProductPhoto",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ProductPhotoID = c.Int(nullable: false),
                        Primary = c.Boolean(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.ProductPhotoID })
                .ForeignKey("Production.ProductPhoto", t => t.ProductPhotoID)
                .ForeignKey("Production.Product", t => t.ProductID)
                .Index(t => t.ProductID)
                .Index(t => t.ProductPhotoID);
            
            CreateTable(
                "Production.ProductPhoto",
                c => new
                    {
                        ProductPhotoID = c.Int(nullable: false, identity: true),
                        ThumbNailPhoto = c.Binary(),
                        ThumbnailPhotoFileName = c.String(maxLength: 50),
                        LargePhoto = c.Binary(),
                        LargePhotoFileName = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductPhotoID);
            
            CreateTable(
                "Production.ProductReview",
                c => new
                    {
                        ProductReviewID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ReviewerName = c.String(nullable: false, maxLength: 50),
                        ReviewDate = c.DateTime(nullable: false),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                        Rating = c.Int(nullable: false),
                        Comments = c.String(maxLength: 3850),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductReviewID)
                .ForeignKey("Production.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "Production.ProductSubcategory",
                c => new
                    {
                        ProductSubcategoryID = c.Int(nullable: false, identity: true),
                        ProductCategoryID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductSubcategoryID)
                .ForeignKey("Production.ProductCategory", t => t.ProductCategoryID)
                .Index(t => t.ProductCategoryID);
            
            CreateTable(
                "Production.ProductCategory",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCategoryID);
            
            CreateTable(
                "Production.TransactionHistory",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ReferenceOrderID = c.Int(nullable: false),
                        ReferenceOrderLineID = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionType = c.String(nullable: false, maxLength: 1, fixedLength: true),
                        Quantity = c.Int(nullable: false),
                        ActualCost = c.Decimal(nullable: false, storeType: "money"),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("Production.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "Production.UnitMeasure",
                c => new
                    {
                        UnitMeasureCode = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UnitMeasureCode);
            
            CreateTable(
                "dbo.DatabaseLog",
                c => new
                    {
                        DatabaseLogID = c.Int(nullable: false, identity: true),
                        PostTime = c.DateTime(nullable: false),
                        DatabaseUser = c.String(nullable: false, maxLength: 128),
                        Event = c.String(nullable: false, maxLength: 128),
                        Schema = c.String(maxLength: 128),
                        Object = c.String(maxLength: 128),
                        TSQL = c.String(nullable: false),
                        XmlEvent = c.String(nullable: false, storeType: "xml"),
                    })
                .PrimaryKey(t => t.DatabaseLogID);
            
            CreateTable(
                "dbo.ErrorLog",
                c => new
                    {
                        ErrorLogID = c.Int(nullable: false, identity: true),
                        ErrorTime = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 128),
                        ErrorNumber = c.Int(nullable: false),
                        ErrorSeverity = c.Int(),
                        ErrorState = c.Int(),
                        ErrorProcedure = c.String(maxLength: 126),
                        ErrorLine = c.Int(),
                        ErrorMessage = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.ErrorLogID);
            
            CreateTable(
                "Sales.ShoppingCartItem",
                c => new
                    {
                        ShoppingCartItemID = c.Int(nullable: false, identity: true),
                        ShoppingCartID = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartItemID);
            
            CreateTable(
                "Production.TransactionHistoryArchive",
                c => new
                    {
                        TransactionID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        ReferenceOrderID = c.Int(nullable: false),
                        ReferenceOrderLineID = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionType = c.String(nullable: false, maxLength: 1, fixedLength: true),
                        Quantity = c.Int(nullable: false),
                        ActualCost = c.Decimal(nullable: false, storeType: "money"),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Production.WorkOrder", "ProductID", "Production.Product");
            DropForeignKey("Production.Product", "WeightUnitMeasureCode", "Production.UnitMeasure");
            DropForeignKey("Production.Product", "SizeUnitMeasureCode", "Production.UnitMeasure");
            DropForeignKey("Production.BillOfMaterials", "UnitMeasureCode", "Production.UnitMeasure");
            DropForeignKey("Production.TransactionHistory", "ProductID", "Production.Product");
            DropForeignKey("Production.ProductSubcategory", "ProductCategoryID", "Production.ProductCategory");
            DropForeignKey("Production.Product", "ProductSubcategoryID", "Production.ProductSubcategory");
            DropForeignKey("Production.ProductReview", "ProductID", "Production.Product");
            DropForeignKey("Production.ProductProductPhoto", "ProductID", "Production.Product");
            DropForeignKey("Production.ProductProductPhoto", "ProductPhotoID", "Production.ProductPhoto");
            DropForeignKey("Production.ProductModelProductDescriptionCulture", "ProductModelID", "Production.ProductModel");
            DropForeignKey("Production.ProductModelProductDescriptionCulture", "ProductDescriptionID", "Production.ProductDescription");
            DropForeignKey("Production.ProductModelProductDescriptionCulture", "CultureID", "Production.Culture");
            DropForeignKey("Production.ProductModelIllustration", "ProductModelID", "Production.ProductModel");
            DropForeignKey("Production.ProductModelIllustration", "IllustrationID", "Production.Illustration");
            DropForeignKey("Production.Product", "ProductModelID", "Production.ProductModel");
            DropForeignKey("Production.ProductListPriceHistory", "ProductID", "Production.Product");
            DropForeignKey("Production.ProductInventory", "ProductID", "Production.Product");
            DropForeignKey("Production.WorkOrderRouting", "LocationID", "Production.Location");
            DropForeignKey("Production.WorkOrderRouting", "WorkOrderID", "Production.WorkOrder");
            DropForeignKey("Production.WorkOrder", "ScrapReasonID", "Production.ScrapReason");
            DropForeignKey("Production.ProductInventory", "LocationID", "Production.Location");
            DropForeignKey("Production.ProductDocument", "ProductID", "Production.Product");
            DropForeignKey("Production.ProductCostHistory", "ProductID", "Production.Product");
            DropForeignKey("Production.BillOfMaterials", "ProductAssemblyID", "Production.Product");
            DropForeignKey("Production.BillOfMaterials", "ComponentID", "Production.Product");
            DropForeignKey("Sales.SalesOrderHeader", "ShipToAddressID", "Person.Address");
            DropForeignKey("Sales.SalesOrderHeader", "BillToAddressID", "Person.Address");
            DropForeignKey("Person.BusinessEntityAddress", "AddressID", "Person.Address");
            DropForeignKey("Purchasing.Vendor", "BusinessEntityID", "Person.BusinessEntity");
            DropForeignKey("Sales.Store", "BusinessEntityID", "Person.BusinessEntity");
            DropForeignKey("Person.Person", "BusinessEntityID", "Person.BusinessEntity");
            DropForeignKey("Person.BusinessEntityContact", "BusinessEntityID", "Person.BusinessEntity");
            DropForeignKey("Person.PersonPhone", "BusinessEntityID", "Person.Person");
            DropForeignKey("Person.PersonPhone", "PhoneNumberTypeID", "Person.PhoneNumberType");
            DropForeignKey("Sales.PersonCreditCard", "BusinessEntityID", "Person.Person");
            DropForeignKey("Person.Password", "BusinessEntityID", "Person.Person");
            DropForeignKey("HumanResources.Employee", "BusinessEntityID", "Person.Person");
            DropForeignKey("Person.EmailAddress", "BusinessEntityID", "Person.Person");
            DropForeignKey("Sales.Customer", "PersonID", "Person.Person");
            DropForeignKey("Sales.SalesOrderHeader", "CustomerID", "Sales.Customer");
            DropForeignKey("Sales.SalesOrderHeaderSalesReason", "SalesReasonID", "Sales.SalesReason");
            DropForeignKey("Sales.SalesOrderHeaderSalesReason", "SalesOrderID", "Sales.SalesOrderHeader");
            DropForeignKey("Sales.SpecialOfferProduct", "SpecialOfferID", "Sales.SpecialOffer");
            DropForeignKey("Sales.SalesOrderDetail", new[] { "SpecialOfferID", "ProductID" }, "Sales.SpecialOfferProduct");
            DropForeignKey("Sales.SalesOrderDetail", "SalesOrderID", "Sales.SalesOrderHeader");
            DropForeignKey("Sales.SalesOrderHeader", "CurrencyRateID", "Sales.CurrencyRate");
            DropForeignKey("Sales.CurrencyRate", "ToCurrencyCode", "Sales.Currency");
            DropForeignKey("Sales.CurrencyRate", "FromCurrencyCode", "Sales.Currency");
            DropForeignKey("Sales.CountryRegionCurrency", "CurrencyCode", "Sales.Currency");
            DropForeignKey("Person.StateProvince", "CountryRegionCode", "Person.CountryRegion");
            DropForeignKey("Sales.SalesTerritory", "CountryRegionCode", "Person.CountryRegion");
            DropForeignKey("Person.StateProvince", "TerritoryID", "Sales.SalesTerritory");
            DropForeignKey("Sales.SalesTaxRate", "StateProvinceID", "Person.StateProvince");
            DropForeignKey("Person.Address", "StateProvinceID", "Person.StateProvince");
            DropForeignKey("Sales.SalesTerritoryHistory", "TerritoryID", "Sales.SalesTerritory");
            DropForeignKey("Sales.Store", "SalesPersonID", "Sales.SalesPerson");
            DropForeignKey("Sales.Customer", "StoreID", "Sales.Store");
            DropForeignKey("Sales.SalesTerritoryHistory", "BusinessEntityID", "Sales.SalesPerson");
            DropForeignKey("Sales.SalesPerson", "TerritoryID", "Sales.SalesTerritory");
            DropForeignKey("Sales.SalesPersonQuotaHistory", "BusinessEntityID", "Sales.SalesPerson");
            DropForeignKey("Sales.SalesOrderHeader", "SalesPersonID", "Sales.SalesPerson");
            DropForeignKey("Sales.SalesPerson", "BusinessEntityID", "HumanResources.Employee");
            DropForeignKey("Purchasing.PurchaseOrderHeader", "EmployeeID", "HumanResources.Employee");
            DropForeignKey("Purchasing.PurchaseOrderHeader", "VendorID", "Purchasing.Vendor");
            DropForeignKey("Purchasing.ProductVendor", "BusinessEntityID", "Purchasing.Vendor");
            DropForeignKey("Sales.SalesOrderHeader", "ShipMethodID", "Purchasing.ShipMethod");
            DropForeignKey("Purchasing.PurchaseOrderHeader", "ShipMethodID", "Purchasing.ShipMethod");
            DropForeignKey("Purchasing.PurchaseOrderDetail", "PurchaseOrderID", "Purchasing.PurchaseOrderHeader");
            DropForeignKey("HumanResources.JobCandidate", "BusinessEntityID", "HumanResources.Employee");
            DropForeignKey("HumanResources.EmployeePayHistory", "BusinessEntityID", "HumanResources.Employee");
            DropForeignKey("HumanResources.EmployeeDepartmentHistory", "BusinessEntityID", "HumanResources.Employee");
            DropForeignKey("HumanResources.EmployeeDepartmentHistory", "ShiftID", "HumanResources.Shift");
            DropForeignKey("HumanResources.EmployeeDepartmentHistory", "DepartmentID", "HumanResources.Department");
            DropForeignKey("Sales.SalesOrderHeader", "TerritoryID", "Sales.SalesTerritory");
            DropForeignKey("Sales.Customer", "TerritoryID", "Sales.SalesTerritory");
            DropForeignKey("Sales.CountryRegionCurrency", "CountryRegionCode", "Person.CountryRegion");
            DropForeignKey("Sales.SalesOrderHeader", "CreditCardID", "Sales.CreditCard");
            DropForeignKey("Sales.PersonCreditCard", "CreditCardID", "Sales.CreditCard");
            DropForeignKey("Person.BusinessEntityContact", "PersonID", "Person.Person");
            DropForeignKey("Person.BusinessEntityContact", "ContactTypeID", "Person.ContactType");
            DropForeignKey("Person.BusinessEntityAddress", "BusinessEntityID", "Person.BusinessEntity");
            DropForeignKey("Person.BusinessEntityAddress", "AddressTypeID", "Person.AddressType");
            DropIndex("Production.TransactionHistory", new[] { "ProductID" });
            DropIndex("Production.ProductSubcategory", new[] { "ProductCategoryID" });
            DropIndex("Production.ProductReview", new[] { "ProductID" });
            DropIndex("Production.ProductProductPhoto", new[] { "ProductPhotoID" });
            DropIndex("Production.ProductProductPhoto", new[] { "ProductID" });
            DropIndex("Production.ProductModelProductDescriptionCulture", new[] { "CultureID" });
            DropIndex("Production.ProductModelProductDescriptionCulture", new[] { "ProductDescriptionID" });
            DropIndex("Production.ProductModelProductDescriptionCulture", new[] { "ProductModelID" });
            DropIndex("Production.ProductModelIllustration", new[] { "IllustrationID" });
            DropIndex("Production.ProductModelIllustration", new[] { "ProductModelID" });
            DropIndex("Production.ProductListPriceHistory", new[] { "ProductID" });
            DropIndex("Production.WorkOrder", new[] { "ScrapReasonID" });
            DropIndex("Production.WorkOrder", new[] { "ProductID" });
            DropIndex("Production.WorkOrderRouting", new[] { "LocationID" });
            DropIndex("Production.WorkOrderRouting", new[] { "WorkOrderID" });
            DropIndex("Production.ProductInventory", new[] { "LocationID" });
            DropIndex("Production.ProductInventory", new[] { "ProductID" });
            DropIndex("Production.ProductDocument", new[] { "ProductID" });
            DropIndex("Production.ProductCostHistory", new[] { "ProductID" });
            DropIndex("Production.Product", new[] { "ProductModelID" });
            DropIndex("Production.Product", new[] { "ProductSubcategoryID" });
            DropIndex("Production.Product", new[] { "WeightUnitMeasureCode" });
            DropIndex("Production.Product", new[] { "SizeUnitMeasureCode" });
            DropIndex("Production.BillOfMaterials", new[] { "UnitMeasureCode" });
            DropIndex("Production.BillOfMaterials", new[] { "ComponentID" });
            DropIndex("Production.BillOfMaterials", new[] { "ProductAssemblyID" });
            DropIndex("Person.PersonPhone", new[] { "PhoneNumberTypeID" });
            DropIndex("Person.PersonPhone", new[] { "BusinessEntityID" });
            DropIndex("Person.Password", new[] { "BusinessEntityID" });
            DropIndex("Person.EmailAddress", new[] { "BusinessEntityID" });
            DropIndex("Sales.SalesOrderHeaderSalesReason", new[] { "SalesReasonID" });
            DropIndex("Sales.SalesOrderHeaderSalesReason", new[] { "SalesOrderID" });
            DropIndex("Sales.SpecialOfferProduct", new[] { "SpecialOfferID" });
            DropIndex("Sales.SalesOrderDetail", new[] { "SpecialOfferID", "ProductID" });
            DropIndex("Sales.SalesOrderDetail", new[] { "SalesOrderID" });
            DropIndex("Sales.SalesTaxRate", new[] { "StateProvinceID" });
            DropIndex("Person.StateProvince", new[] { "TerritoryID" });
            DropIndex("Person.StateProvince", new[] { "CountryRegionCode" });
            DropIndex("Sales.Store", new[] { "SalesPersonID" });
            DropIndex("Sales.Store", new[] { "BusinessEntityID" });
            DropIndex("Sales.SalesTerritoryHistory", new[] { "TerritoryID" });
            DropIndex("Sales.SalesTerritoryHistory", new[] { "BusinessEntityID" });
            DropIndex("Sales.SalesPersonQuotaHistory", new[] { "BusinessEntityID" });
            DropIndex("Purchasing.ProductVendor", new[] { "BusinessEntityID" });
            DropIndex("Purchasing.Vendor", new[] { "BusinessEntityID" });
            DropIndex("Purchasing.PurchaseOrderDetail", new[] { "PurchaseOrderID" });
            DropIndex("Purchasing.PurchaseOrderHeader", new[] { "ShipMethodID" });
            DropIndex("Purchasing.PurchaseOrderHeader", new[] { "VendorID" });
            DropIndex("Purchasing.PurchaseOrderHeader", new[] { "EmployeeID" });
            DropIndex("HumanResources.JobCandidate", new[] { "BusinessEntityID" });
            DropIndex("HumanResources.EmployeePayHistory", new[] { "BusinessEntityID" });
            DropIndex("HumanResources.EmployeeDepartmentHistory", new[] { "ShiftID" });
            DropIndex("HumanResources.EmployeeDepartmentHistory", new[] { "DepartmentID" });
            DropIndex("HumanResources.EmployeeDepartmentHistory", new[] { "BusinessEntityID" });
            DropIndex("HumanResources.Employee", new[] { "BusinessEntityID" });
            DropIndex("Sales.SalesPerson", new[] { "TerritoryID" });
            DropIndex("Sales.SalesPerson", new[] { "BusinessEntityID" });
            DropIndex("Sales.SalesTerritory", new[] { "CountryRegionCode" });
            DropIndex("Sales.CountryRegionCurrency", new[] { "CurrencyCode" });
            DropIndex("Sales.CountryRegionCurrency", new[] { "CountryRegionCode" });
            DropIndex("Sales.CurrencyRate", new[] { "ToCurrencyCode" });
            DropIndex("Sales.CurrencyRate", new[] { "FromCurrencyCode" });
            DropIndex("Sales.PersonCreditCard", new[] { "CreditCardID" });
            DropIndex("Sales.PersonCreditCard", new[] { "BusinessEntityID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "CurrencyRateID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "CreditCardID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "ShipMethodID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "ShipToAddressID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "BillToAddressID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "TerritoryID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "SalesPersonID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "CustomerID" });
            DropIndex("Sales.Customer", new[] { "TerritoryID" });
            DropIndex("Sales.Customer", new[] { "StoreID" });
            DropIndex("Sales.Customer", new[] { "PersonID" });
            DropIndex("Person.Person", new[] { "BusinessEntityID" });
            DropIndex("Person.BusinessEntityContact", new[] { "ContactTypeID" });
            DropIndex("Person.BusinessEntityContact", new[] { "PersonID" });
            DropIndex("Person.BusinessEntityContact", new[] { "BusinessEntityID" });
            DropIndex("Person.BusinessEntityAddress", new[] { "AddressTypeID" });
            DropIndex("Person.BusinessEntityAddress", new[] { "AddressID" });
            DropIndex("Person.BusinessEntityAddress", new[] { "BusinessEntityID" });
            DropIndex("Person.Address", new[] { "StateProvinceID" });
            DropTable("Production.TransactionHistoryArchive");
            DropTable("Sales.ShoppingCartItem");
            DropTable("dbo.ErrorLog");
            DropTable("dbo.DatabaseLog");
            DropTable("Production.UnitMeasure");
            DropTable("Production.TransactionHistory");
            DropTable("Production.ProductCategory");
            DropTable("Production.ProductSubcategory");
            DropTable("Production.ProductReview");
            DropTable("Production.ProductPhoto");
            DropTable("Production.ProductProductPhoto");
            DropTable("Production.ProductDescription");
            DropTable("Production.Culture");
            DropTable("Production.ProductModelProductDescriptionCulture");
            DropTable("Production.Illustration");
            DropTable("Production.ProductModelIllustration");
            DropTable("Production.ProductModel");
            DropTable("Production.ProductListPriceHistory");
            DropTable("Production.ScrapReason");
            DropTable("Production.WorkOrder");
            DropTable("Production.WorkOrderRouting");
            DropTable("Production.Location");
            DropTable("Production.ProductInventory");
            DropTable("Production.ProductDocument");
            DropTable("Production.ProductCostHistory");
            DropTable("Production.Product");
            DropTable("Production.BillOfMaterials");
            DropTable("dbo.AWBuildVersion");
            DropTable("Person.PhoneNumberType");
            DropTable("Person.PersonPhone");
            DropTable("Person.Password");
            DropTable("Person.EmailAddress");
            DropTable("Sales.SalesReason");
            DropTable("Sales.SalesOrderHeaderSalesReason");
            DropTable("Sales.SpecialOffer");
            DropTable("Sales.SpecialOfferProduct");
            DropTable("Sales.SalesOrderDetail");
            DropTable("Sales.SalesTaxRate");
            DropTable("Person.StateProvince");
            DropTable("Sales.Store");
            DropTable("Sales.SalesTerritoryHistory");
            DropTable("Sales.SalesPersonQuotaHistory");
            DropTable("Purchasing.ProductVendor");
            DropTable("Purchasing.Vendor");
            DropTable("Purchasing.ShipMethod");
            DropTable("Purchasing.PurchaseOrderDetail");
            DropTable("Purchasing.PurchaseOrderHeader");
            DropTable("HumanResources.JobCandidate");
            DropTable("HumanResources.EmployeePayHistory");
            DropTable("HumanResources.Shift");
            DropTable("HumanResources.Department");
            DropTable("HumanResources.EmployeeDepartmentHistory");
            DropTable("HumanResources.Employee");
            DropTable("Sales.SalesPerson");
            DropTable("Sales.SalesTerritory");
            DropTable("Person.CountryRegion");
            DropTable("Sales.CountryRegionCurrency");
            DropTable("Sales.Currency");
            DropTable("Sales.CurrencyRate");
            DropTable("Sales.PersonCreditCard");
            DropTable("Sales.CreditCard");
            DropTable("Sales.SalesOrderHeader");
            DropTable("Sales.Customer");
            DropTable("Person.Person");
            DropTable("Person.ContactType");
            DropTable("Person.BusinessEntityContact");
            DropTable("Person.BusinessEntity");
            DropTable("Person.AddressType");
            DropTable("Person.BusinessEntityAddress");
            DropTable("Person.Address");
        }
    }
}
