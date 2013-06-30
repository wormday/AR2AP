
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/30/2013 23:25:15
-- Generated from EDMX file: C:\Projects\AR2AP\AR2AP.BLL\AR2AP.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AR2AP];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AREntityClientEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AREntities] DROP CONSTRAINT [FK_AREntityClientEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_AgencyEntityAREntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AREntities] DROP CONSTRAINT [FK_AgencyEntityAREntity];
GO
IF OBJECT_ID(N'[dbo].[FK_AREntityTermEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AREntities] DROP CONSTRAINT [FK_AREntityTermEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_ARRelatedEmpEntityAREntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ARRelatedEmpEntities] DROP CONSTRAINT [FK_ARRelatedEmpEntityAREntity];
GO
IF OBJECT_ID(N'[dbo].[FK_ARRelatedEmpEntityEmpEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ARRelatedEmpEntities] DROP CONSTRAINT [FK_ARRelatedEmpEntityEmpEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_CollectionClientEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollectionEntities] DROP CONSTRAINT [FK_CollectionClientEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_CollectionEntityAgencyEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollectionEntities] DROP CONSTRAINT [FK_CollectionEntityAgencyEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_WriteOffEntityAREntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WriteOffEntities] DROP CONSTRAINT [FK_WriteOffEntityAREntity];
GO
IF OBJECT_ID(N'[dbo].[FK_WriteOffEntityCollectionEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WriteOffEntities] DROP CONSTRAINT [FK_WriteOffEntityCollectionEntity];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AgencyEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AgencyEntities];
GO
IF OBJECT_ID(N'[dbo].[ClientEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientEntities];
GO
IF OBJECT_ID(N'[dbo].[AREntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AREntities];
GO
IF OBJECT_ID(N'[dbo].[TeamEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamEntities];
GO
IF OBJECT_ID(N'[dbo].[EmpEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmpEntities];
GO
IF OBJECT_ID(N'[dbo].[ARRelatedEmpEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ARRelatedEmpEntities];
GO
IF OBJECT_ID(N'[dbo].[CollectionEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollectionEntities];
GO
IF OBJECT_ID(N'[dbo].[WriteOffEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WriteOffEntities];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AgencyEntities'
CREATE TABLE [dbo].[AgencyEntities] (
    [AgencyID] smallint IDENTITY(1,1) NOT NULL,
    [AgencyName] nvarchar(max)  NOT NULL,
    [CurrencyType] tinyint  NOT NULL
);
GO

-- Creating table 'ClientEntities'
CREATE TABLE [dbo].[ClientEntities] (
    [ClientID] smallint IDENTITY(1,1) NOT NULL,
    [ClientType] tinyint  NOT NULL,
    [ClientGroup] nvarchar(max)  NOT NULL,
    [ClientName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AREntities'
CREATE TABLE [dbo].[AREntities] (
    [ARID] int IDENTITY(1,1) NOT NULL,
    [ClientID] smallint  NOT NULL,
    [AgencyID] smallint  NOT NULL,
    [TeamID] smallint  NOT NULL,
    [ProjectNo] varchar(50)  NULL,
    [ContractNo] varchar(50)  NULL,
    [Campaingn] nvarchar(200)  NOT NULL,
    [CompaignStart] datetime  NOT NULL,
    [CompaignEnd] datetime  NOT NULL,
    [CompaignAmount] decimal(12,2)  NOT NULL,
    [DueDate] datetime  NOT NULL,
    [InvoiceNo] varchar(50)  NULL,
    [InvoiceDate] datetime  NULL,
    [InvoiceType] tinyint  NULL,
    [InvoiceAmount] decimal(12,2)  NULL,
    [RevenueConfirmationDate] datetime  NOT NULL,
    [Remark] nvarchar(max)  NULL
);
GO

-- Creating table 'TeamEntities'
CREATE TABLE [dbo].[TeamEntities] (
    [TeamID] smallint IDENTITY(1,1) NOT NULL,
    [Market] nvarchar(10)  NOT NULL,
    [Depart] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'EmpEntities'
CREATE TABLE [dbo].[EmpEntities] (
    [EmpID] smallint IDENTITY(1,1) NOT NULL,
    [EmpName] nvarchar(200)  NOT NULL,
    [EmpEmail] varchar(200)  NULL,
    [Username] varchar(16)  NULL,
    [Password] varchar(32)  NULL
);
GO

-- Creating table 'ARRelatedEmpEntities'
CREATE TABLE [dbo].[ARRelatedEmpEntities] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ARID] int  NOT NULL,
    [EmpID] smallint  NOT NULL
);
GO

-- Creating table 'CollectionEntities'
CREATE TABLE [dbo].[CollectionEntities] (
    [CollectionID] int IDENTITY(1,1) NOT NULL,
    [ClientID] smallint  NULL,
    [CollectionDate] datetime  NOT NULL,
    [AgencyID] smallint  NOT NULL,
    [CollectionAmount] decimal(12,2)  NOT NULL,
    [CollectionRemark] nvarchar(max)  NULL
);
GO

-- Creating table 'WriteOffEntities'
CREATE TABLE [dbo].[WriteOffEntities] (
    [WriteOffID] int IDENTITY(1,1) NOT NULL,
    [ARID] int  NOT NULL,
    [CollectionID] int  NOT NULL,
    [WriteOffDate] datetime  NOT NULL,
    [WriteOffAmount] decimal(12,2)  NOT NULL,
    [WriteOffRemark] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AgencyID] in table 'AgencyEntities'
ALTER TABLE [dbo].[AgencyEntities]
ADD CONSTRAINT [PK_AgencyEntities]
    PRIMARY KEY CLUSTERED ([AgencyID] ASC);
GO

-- Creating primary key on [ClientID] in table 'ClientEntities'
ALTER TABLE [dbo].[ClientEntities]
ADD CONSTRAINT [PK_ClientEntities]
    PRIMARY KEY CLUSTERED ([ClientID] ASC);
GO

-- Creating primary key on [ARID] in table 'AREntities'
ALTER TABLE [dbo].[AREntities]
ADD CONSTRAINT [PK_AREntities]
    PRIMARY KEY CLUSTERED ([ARID] ASC);
GO

-- Creating primary key on [TeamID] in table 'TeamEntities'
ALTER TABLE [dbo].[TeamEntities]
ADD CONSTRAINT [PK_TeamEntities]
    PRIMARY KEY CLUSTERED ([TeamID] ASC);
GO

-- Creating primary key on [EmpID] in table 'EmpEntities'
ALTER TABLE [dbo].[EmpEntities]
ADD CONSTRAINT [PK_EmpEntities]
    PRIMARY KEY CLUSTERED ([EmpID] ASC);
GO

-- Creating primary key on [ID] in table 'ARRelatedEmpEntities'
ALTER TABLE [dbo].[ARRelatedEmpEntities]
ADD CONSTRAINT [PK_ARRelatedEmpEntities]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [CollectionID] in table 'CollectionEntities'
ALTER TABLE [dbo].[CollectionEntities]
ADD CONSTRAINT [PK_CollectionEntities]
    PRIMARY KEY CLUSTERED ([CollectionID] ASC);
GO

-- Creating primary key on [WriteOffID] in table 'WriteOffEntities'
ALTER TABLE [dbo].[WriteOffEntities]
ADD CONSTRAINT [PK_WriteOffEntities]
    PRIMARY KEY CLUSTERED ([WriteOffID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClientID] in table 'AREntities'
ALTER TABLE [dbo].[AREntities]
ADD CONSTRAINT [FK_AREntityClientEntity]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[ClientEntities]
        ([ClientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AREntityClientEntity'
CREATE INDEX [IX_FK_AREntityClientEntity]
ON [dbo].[AREntities]
    ([ClientID]);
GO

-- Creating foreign key on [AgencyID] in table 'AREntities'
ALTER TABLE [dbo].[AREntities]
ADD CONSTRAINT [FK_AgencyEntityAREntity]
    FOREIGN KEY ([AgencyID])
    REFERENCES [dbo].[AgencyEntities]
        ([AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AgencyEntityAREntity'
CREATE INDEX [IX_FK_AgencyEntityAREntity]
ON [dbo].[AREntities]
    ([AgencyID]);
GO

-- Creating foreign key on [TeamID] in table 'AREntities'
ALTER TABLE [dbo].[AREntities]
ADD CONSTRAINT [FK_AREntityTermEntity]
    FOREIGN KEY ([TeamID])
    REFERENCES [dbo].[TeamEntities]
        ([TeamID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AREntityTermEntity'
CREATE INDEX [IX_FK_AREntityTermEntity]
ON [dbo].[AREntities]
    ([TeamID]);
GO

-- Creating foreign key on [ARID] in table 'ARRelatedEmpEntities'
ALTER TABLE [dbo].[ARRelatedEmpEntities]
ADD CONSTRAINT [FK_ARRelatedEmpEntityAREntity]
    FOREIGN KEY ([ARID])
    REFERENCES [dbo].[AREntities]
        ([ARID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ARRelatedEmpEntityAREntity'
CREATE INDEX [IX_FK_ARRelatedEmpEntityAREntity]
ON [dbo].[ARRelatedEmpEntities]
    ([ARID]);
GO

-- Creating foreign key on [EmpID] in table 'ARRelatedEmpEntities'
ALTER TABLE [dbo].[ARRelatedEmpEntities]
ADD CONSTRAINT [FK_ARRelatedEmpEntityEmpEntity]
    FOREIGN KEY ([EmpID])
    REFERENCES [dbo].[EmpEntities]
        ([EmpID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ARRelatedEmpEntityEmpEntity'
CREATE INDEX [IX_FK_ARRelatedEmpEntityEmpEntity]
ON [dbo].[ARRelatedEmpEntities]
    ([EmpID]);
GO

-- Creating foreign key on [ClientID] in table 'CollectionEntities'
ALTER TABLE [dbo].[CollectionEntities]
ADD CONSTRAINT [FK_CollectionClientEntity]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[ClientEntities]
        ([ClientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CollectionClientEntity'
CREATE INDEX [IX_FK_CollectionClientEntity]
ON [dbo].[CollectionEntities]
    ([ClientID]);
GO

-- Creating foreign key on [AgencyID] in table 'CollectionEntities'
ALTER TABLE [dbo].[CollectionEntities]
ADD CONSTRAINT [FK_CollectionEntityAgencyEntity]
    FOREIGN KEY ([AgencyID])
    REFERENCES [dbo].[AgencyEntities]
        ([AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CollectionEntityAgencyEntity'
CREATE INDEX [IX_FK_CollectionEntityAgencyEntity]
ON [dbo].[CollectionEntities]
    ([AgencyID]);
GO

-- Creating foreign key on [ARID] in table 'WriteOffEntities'
ALTER TABLE [dbo].[WriteOffEntities]
ADD CONSTRAINT [FK_WriteOffEntityAREntity]
    FOREIGN KEY ([ARID])
    REFERENCES [dbo].[AREntities]
        ([ARID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WriteOffEntityAREntity'
CREATE INDEX [IX_FK_WriteOffEntityAREntity]
ON [dbo].[WriteOffEntities]
    ([ARID]);
GO

-- Creating foreign key on [CollectionID] in table 'WriteOffEntities'
ALTER TABLE [dbo].[WriteOffEntities]
ADD CONSTRAINT [FK_WriteOffEntityCollectionEntity]
    FOREIGN KEY ([CollectionID])
    REFERENCES [dbo].[CollectionEntities]
        ([CollectionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WriteOffEntityCollectionEntity'
CREATE INDEX [IX_FK_WriteOffEntityCollectionEntity]
ON [dbo].[WriteOffEntities]
    ([CollectionID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------