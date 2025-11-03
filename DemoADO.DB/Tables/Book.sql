CREATE TABLE [dbo].[Book]
(
	[Id] INT IDENTITY, 
    [Title] VARCHAR(100) NOT NULL, 
    [ISBN] VARCHAR(13) NULL,
    [ReleaseDate] DateTime NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY ([Id])
)
