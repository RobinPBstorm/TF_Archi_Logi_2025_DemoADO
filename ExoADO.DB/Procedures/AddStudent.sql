CREATE PROCEDURE [dbo].[AddStudent]
	@firstName VARCHAR(50),
	@lastName VARCHAR(50),
	@birthDate DATETIME2(7),
	@yearResult INT,
	@sectionId INT
AS
	INSERT INTO [Student] (FirstName, LastName, BirthDate, YearResult, SectionId, Active)
	VALUES (@firstName, @lastName, @birthDate, @yearResult, @sectionId, DEFAULT);
