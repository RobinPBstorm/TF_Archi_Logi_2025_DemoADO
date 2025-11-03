CREATE TABLE [dbo].[Author]
(
	[Id] INT IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [PenName] VARCHAR(50) NULL, 
    [Origin] VARCHAR(25) NOT NULL, 
    [IsAlive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Author] PRIMARY KEY ([id])
)
