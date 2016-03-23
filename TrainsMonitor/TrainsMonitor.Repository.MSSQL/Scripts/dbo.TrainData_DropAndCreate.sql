USE [trainsmonitorDb]
GO

/****** Object: Table [dbo].[TrainData] Script Date: 3/23/2016 1:58:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[TrainData];


GO
CREATE TABLE [dbo].[TrainData] (
    [Id]                       INT           NOT NULL,
    [PackageNumber]            SMALLINT      NULL,
    [SystemSerialNumber]       SMALLINT      NULL,
    [ProviderName]             NVARCHAR (15) NULL,
    [SystemFlag]               BIT           NULL,
    [DateTime]                 DATETIME      NULL,
    [EnvironmentTemperature]   FLOAT (53)    NULL,
    [Radiator1Temperature]     FLOAT (53)    NULL,
    [Radiator2Temperature]     FLOAT (53)    NULL,
    [FootstepTemperature]      FLOAT (53)    NULL,
    [TurbineTemperature]       FLOAT (53)    NULL,
    [OilTemperature]           FLOAT (53)    NULL,
    [TransformatorTemperature] FLOAT (53)    NULL,
    [CabinTemperature]         FLOAT (53)    NULL,
    [Voltage]                  FLOAT (53)    NULL,
    [Heater1FuelConsumption]   FLOAT (53)    NULL,
    [Heater2FuelConsumption]   FLOAT (53)    NULL,
    [AirHeaterFuelConsumption] FLOAT (53)    NULL,
    [Heater1Flags]             SMALLINT      NULL,
    [Heater2Flags]             SMALLINT      NULL,
    [HeaterAirFlags]           SMALLINT      NULL,
    [SystemFlags]              TINYINT       NULL
);


