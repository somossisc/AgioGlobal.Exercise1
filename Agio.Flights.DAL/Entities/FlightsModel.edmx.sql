
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/09/2018 18:06:48
-- Generated from EDMX file: D:\AgioGlobal.Exercise1\Agio.Flights.DAL\Entities\FlightsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AgioGlobal];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AirportFlightOrigin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Flights] DROP CONSTRAINT [FK_AirportFlightOrigin];
GO
IF OBJECT_ID(N'[dbo].[FK_AirportFlight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Flights] DROP CONSTRAINT [FK_AirportFlight];
GO
IF OBJECT_ID(N'[dbo].[FK_AircraftFlight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Flights] DROP CONSTRAINT [FK_AircraftFlight];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Airports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Airports];
GO
IF OBJECT_ID(N'[dbo].[Aircraft]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Aircraft];
GO
IF OBJECT_ID(N'[dbo].[Flights]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Flights];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Airports'
CREATE TABLE [dbo].[Airports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Iata] nvarchar(3)  NOT NULL,
    [Latitude] float  NOT NULL,
    [Longitude] float  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Aircraft'
CREATE TABLE [dbo].[Aircraft] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [TakeoffEffort] float  NOT NULL
);
GO

-- Creating table 'Flights'
CREATE TABLE [dbo].[Flights] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OriginAirportId] int  NOT NULL,
    [DestinationAirportId] int  NOT NULL,
    [AircraftId] int  NOT NULL,
    [Time] time  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Airports'
ALTER TABLE [dbo].[Airports]
ADD CONSTRAINT [PK_Airports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Aircraft'
ALTER TABLE [dbo].[Aircraft]
ADD CONSTRAINT [PK_Aircraft]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Flights'
ALTER TABLE [dbo].[Flights]
ADD CONSTRAINT [PK_Flights]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OriginAirportId] in table 'Flights'
ALTER TABLE [dbo].[Flights]
ADD CONSTRAINT [FK_AirportFlightOrigin]
    FOREIGN KEY ([OriginAirportId])
    REFERENCES [dbo].[Airports]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AirportFlightOrigin'
CREATE INDEX [IX_FK_AirportFlightOrigin]
ON [dbo].[Flights]
    ([OriginAirportId]);
GO

-- Creating foreign key on [DestinationAirportId] in table 'Flights'
ALTER TABLE [dbo].[Flights]
ADD CONSTRAINT [FK_AirportFlight]
    FOREIGN KEY ([DestinationAirportId])
    REFERENCES [dbo].[Airports]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AirportFlight'
CREATE INDEX [IX_FK_AirportFlight]
ON [dbo].[Flights]
    ([DestinationAirportId]);
GO

-- Creating foreign key on [AircraftId] in table 'Flights'
ALTER TABLE [dbo].[Flights]
ADD CONSTRAINT [FK_AircraftFlight]
    FOREIGN KEY ([AircraftId])
    REFERENCES [dbo].[Aircraft]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AircraftFlight'
CREATE INDEX [IX_FK_AircraftFlight]
ON [dbo].[Flights]
    ([AircraftId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------