CREATE TABLE [dbo].[Student]
(
	[Id] INT IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[BirthDate] DATETIME2(7) NOT NULL,
	[YearResult] INT NOT NULL,
	[SectionId] INT NOT NULL,
	[Active] BIT NOT NULL DEFAULT 1,

	CONSTRAINT [PK_Student] PRIMARY KEY ([Id]),
	CONSTRAINT [CK_Student_YearResult] CHECK ([YearResult] BETWEEN 0 AND 20),
	CONSTRAINT [CK_Student_BirthDate] CHECK ([BirthDate] >= '1930-01-01')

)
