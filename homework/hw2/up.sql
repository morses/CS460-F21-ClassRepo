-- UP script for SQL Server

CREATE TABLE [Peak] (
  [ID]              INT           PRIMARY KEY IDENTITY(1, 1),
  [Name]            NVARCHAR(30)  NOT NULL,
  [Height]          INT           NOT NULL,
  [ClimbingStatus]  BIT           NOT NULL,
  [FirstAscentYear] INT
)

CREATE TABLE [Expedition] (
  [ID]                INT             PRIMARY KEY IDENTITY(1, 1),
  [Season]            NVARCHAR(10)    NOT NULL,
  [Year]              INT             NOT NULL,
  [StartDate]         DATE            NOT NULL,
  [TerminationReason] NVARCHAR(80),
  [OxygenUsed]        BIT             NOT NULL,
  [PeakID]            INT             NOT NULL,
  [TrekkingAgencyID]  INT             NOT NULL
)

CREATE TABLE [TrekkingAgency] (
  [ID]    INT             PRIMARY KEY IDENTITY(1, 1),
  [Name]  NVARCHAR(100)   NOT NULL
)

ALTER TABLE [Expedition] ADD CONSTRAINT [Expedition_FK_Peak]           FOREIGN KEY ([PeakID])           REFERENCES [Peak]           ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Expedition] ADD CONSTRAINT [Expedition_FK_TrekkingAgency] FOREIGN KEY ([TrekkingAgencyID]) REFERENCES [TrekkingAgency] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
