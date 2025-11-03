CREATE PROCEDURE [dbo].[DeleteStudent]
	@id INT
AS
	DELETE [Student]
	WHERE Id = @id
