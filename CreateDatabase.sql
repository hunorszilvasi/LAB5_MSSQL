IF DB_ID(N'MagazinDB') IS NULL
BEGIN
    CREATE DATABASE [MagazinDB];
END;
GO

USE [MagazinDB];
GO

IF OBJECT_ID(N'dbo.CategoriiProduse', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CategoriiProduse
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_CategoriiProduse PRIMARY KEY,
        Denumire nvarchar(100) NOT NULL
    );
    CREATE UNIQUE INDEX IX_CategoriiProduse_Denumire ON dbo.CategoriiProduse(Denumire);
END;
GO

IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Products
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Products PRIMARY KEY,
        Name nvarchar(30) NOT NULL,
        Description nvarchar(500) NOT NULL,
        EntryDate datetime2 NOT NULL,
        ExpirationDate datetime2 NOT NULL,
        Quantity int NOT NULL,
        IdCategorie int NOT NULL,
        CONSTRAINT FK_Products_CategoriiProduse_IdCategorie
            FOREIGN KEY (IdCategorie) REFERENCES dbo.CategoriiProduse(Id) ON DELETE NO ACTION
    );
END;
GO

IF OBJECT_ID(N'dbo.IstoricVanzari', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.IstoricVanzari
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_IstoricVanzari PRIMARY KEY,
        IdProdus int NOT NULL,
        Cantitate int NOT NULL,
        CONSTRAINT FK_IstoricVanzari_Products_IdProdus
            FOREIGN KEY (IdProdus) REFERENCES dbo.Products(Id) ON DELETE NO ACTION
    );
END;
GO
