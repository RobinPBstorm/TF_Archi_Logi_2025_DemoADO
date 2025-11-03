CREATE PROCEDURE [dbo].[UpdateStudent]
	@id INT,
	@sectionId INT,
	@yearResult INT
AS
	UPDATE Student
	SET SectionId = @sectionId, YearResult = @yearResult
	WHERE Id = @id
