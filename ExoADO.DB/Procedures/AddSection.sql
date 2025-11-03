CREATE PROCEDURE [dbo].[AddSection]
	@id INT,
	@sectionName VARCHAR(50)
AS
	INSERT INTO [section] (Id, SectionName)
	VALUES (@Id, @sectionName);