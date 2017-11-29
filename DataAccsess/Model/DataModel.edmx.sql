
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/29/2017 19:21:23
-- Generated from EDMX file: C:\Users\N\Source\Repos\Shop\DataAccsess\Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Shop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductProductType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductSet] DROP CONSTRAINT [FK_ProductProductType];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductProductImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductImageSet] DROP CONSTRAINT [FK_ProductProductImage];
GO
IF OBJECT_ID(N'[dbo].[FK_PricesPriceType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PricesSet] DROP CONSTRAINT [FK_PricesPriceType];
GO
IF OBJECT_ID(N'[dbo].[FK_PricesProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PricesSet] DROP CONSTRAINT [FK_PricesProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderOrderRows]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderRowsSet] DROP CONSTRAINT [FK_OrderOrderRows];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderRowsProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderRowsSet] DROP CONSTRAINT [FK_OrderRowsProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_PriceTypeOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_PriceTypeOrder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[dbo].[ProductTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductTypeSet];
GO
IF OBJECT_ID(N'[dbo].[PriceTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PriceTypeSet];
GO
IF OBJECT_ID(N'[dbo].[PricesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PricesSet];
GO
IF OBJECT_ID(N'[dbo].[ProductImageSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductImageSet];
GO
IF OBJECT_ID(N'[dbo].[OrderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderSet];
GO
IF OBJECT_ID(N'[dbo].[OrderRowsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderRowsSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ShortDescription] nvarchar(150)  NOT NULL,
    [ProductType_Id] int  NOT NULL
);
GO

-- Creating table 'ProductTypeSet'
CREATE TABLE [dbo].[ProductTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PriceTypeSet'
CREATE TABLE [dbo].[PriceTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PricesSet'
CREATE TABLE [dbo].[PricesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [PriceType_Id] int  NOT NULL,
    [Product_Id] int  NOT NULL
);
GO

-- Creating table 'ProductImageSet'
CREATE TABLE [dbo].[ProductImageSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Image] varbinary(max)  NOT NULL,
    [ProductProductImage_ProductImage_Id] int  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Payed] bit  NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [PaymentType] int  NOT NULL,
    [PriceType_Id] int  NOT NULL
);
GO

-- Creating table 'OrderRowsSet'
CREATE TABLE [dbo].[OrderRowsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderId] int  NOT NULL,
    [Qty] decimal(18,0)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Sum] decimal(18,0)  NOT NULL,
    [Product_Id] int  NOT NULL
);
GO

-- Creating table 'NewsSet'
CREATE TABLE [dbo].[NewsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductTypeSet'
ALTER TABLE [dbo].[ProductTypeSet]
ADD CONSTRAINT [PK_ProductTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PriceTypeSet'
ALTER TABLE [dbo].[PriceTypeSet]
ADD CONSTRAINT [PK_PriceTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PricesSet'
ALTER TABLE [dbo].[PricesSet]
ADD CONSTRAINT [PK_PricesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductImageSet'
ALTER TABLE [dbo].[ProductImageSet]
ADD CONSTRAINT [PK_ProductImageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderRowsSet'
ALTER TABLE [dbo].[OrderRowsSet]
ADD CONSTRAINT [PK_OrderRowsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NewsSet'
ALTER TABLE [dbo].[NewsSet]
ADD CONSTRAINT [PK_NewsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProductType_Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_ProductProductType]
    FOREIGN KEY ([ProductType_Id])
    REFERENCES [dbo].[ProductTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductType'
CREATE INDEX [IX_FK_ProductProductType]
ON [dbo].[ProductSet]
    ([ProductType_Id]);
GO

-- Creating foreign key on [ProductProductImage_ProductImage_Id] in table 'ProductImageSet'
ALTER TABLE [dbo].[ProductImageSet]
ADD CONSTRAINT [FK_ProductProductImage]
    FOREIGN KEY ([ProductProductImage_ProductImage_Id])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductImage'
CREATE INDEX [IX_FK_ProductProductImage]
ON [dbo].[ProductImageSet]
    ([ProductProductImage_ProductImage_Id]);
GO

-- Creating foreign key on [PriceType_Id] in table 'PricesSet'
ALTER TABLE [dbo].[PricesSet]
ADD CONSTRAINT [FK_PricesPriceType]
    FOREIGN KEY ([PriceType_Id])
    REFERENCES [dbo].[PriceTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PricesPriceType'
CREATE INDEX [IX_FK_PricesPriceType]
ON [dbo].[PricesSet]
    ([PriceType_Id]);
GO

-- Creating foreign key on [Product_Id] in table 'PricesSet'
ALTER TABLE [dbo].[PricesSet]
ADD CONSTRAINT [FK_PricesProduct]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PricesProduct'
CREATE INDEX [IX_FK_PricesProduct]
ON [dbo].[PricesSet]
    ([Product_Id]);
GO

-- Creating foreign key on [OrderId] in table 'OrderRowsSet'
ALTER TABLE [dbo].[OrderRowsSet]
ADD CONSTRAINT [FK_OrderOrderRows]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[OrderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderRows'
CREATE INDEX [IX_FK_OrderOrderRows]
ON [dbo].[OrderRowsSet]
    ([OrderId]);
GO

-- Creating foreign key on [Product_Id] in table 'OrderRowsSet'
ALTER TABLE [dbo].[OrderRowsSet]
ADD CONSTRAINT [FK_OrderRowsProduct]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderRowsProduct'
CREATE INDEX [IX_FK_OrderRowsProduct]
ON [dbo].[OrderRowsSet]
    ([Product_Id]);
GO

-- Creating foreign key on [PriceType_Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_PriceTypeOrder]
    FOREIGN KEY ([PriceType_Id])
    REFERENCES [dbo].[PriceTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PriceTypeOrder'
CREATE INDEX [IX_FK_PriceTypeOrder]
ON [dbo].[OrderSet]
    ([PriceType_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------